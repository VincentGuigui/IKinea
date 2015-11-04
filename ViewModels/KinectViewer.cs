//------------------------------------------------------------------------------
// <copyright file="KinectColorViewer.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;

namespace IKinea.ViewModels
{
    /// <summary>
    /// Interaction logic for KinectColorViewer.xaml
    /// </summary>
    public partial class KinectViewer : ViewModelBase
    {
        private ColorImageFormat _lastImageFormat = ColorImageFormat.Undefined;
        private byte[] _rawPixelData;
        private byte[] _pixelData;
        private WriteableBitmap _view;

        public WriteableBitmap View
        {
            get { return _view; }
            set
            {
                _view = value;
                OnPropertyChanged("View");
            }
        }


        public void OnKinectSensorChanged(object sender, KinectChangedEventArgs args)
        {
            if (null == args)
            {
                throw new ArgumentNullException("args");
            }

            if (null != args.OldSensor)
            {
                args.OldSensor.ColorFrameReady -= this.ColorImageReady;

            }

            if ((null != args.NewSensor) && (KinectStatus.Connected == args.NewSensor.Status))
            {
                if (ColorImageFormat.RawYuvResolution640x480Fps15 == args.NewSensor.ColorStream.Format)
                {
                    throw new NotImplementedException("RawYuv conversion is not yet implemented.");
                }
                else
                {
                    args.NewSensor.ColorFrameReady += this.ColorImageReady;
                }
            }
        }

        private void ConvertBayerToRgb32(int width, int height)
        {
            // Demosaic using a basic nearest-neighbor algorithm, operating on groups of four pixels.
            for (int y = 0; y < height; y += 2)
            {
                for (int x = 0; x < width; x += 2)
                {
                    int firstRowOffset = (y * width) + x;
                    int secondRowOffset = firstRowOffset + width;

                    // Cache the Bayer component values.
                    byte red = _rawPixelData[firstRowOffset + 1];
                    byte green1 = _rawPixelData[firstRowOffset];
                    byte green2 = _rawPixelData[secondRowOffset + 1];
                    byte blue = _rawPixelData[secondRowOffset];

                    // Adjust offsets for RGB.
                    firstRowOffset *= 4;
                    secondRowOffset *= 4;

                    // Top left
                    _pixelData[firstRowOffset] = blue;
                    _pixelData[firstRowOffset + 1] = green1;
                    _pixelData[firstRowOffset + 2] = red;

                    // Top right
                    _pixelData[firstRowOffset + 4] = blue;
                    _pixelData[firstRowOffset + 5] = green1;
                    _pixelData[firstRowOffset + 6] = red;

                    // Bottom left
                    _pixelData[secondRowOffset] = blue;
                    _pixelData[secondRowOffset + 1] = green2;
                    _pixelData[secondRowOffset + 2] = red;

                    // Bottom right
                    _pixelData[secondRowOffset + 4] = blue;
                    _pixelData[secondRowOffset + 5] = green2;
                    _pixelData[secondRowOffset + 6] = red;
                }
            }
        }

        private void ColorImageReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame imageFrame = e.OpenColorImageFrame())
            {
                if (imageFrame != null)
                {
                    // We need to detect if the format has changed.
                    bool haveNewFormat = this._lastImageFormat != imageFrame.Format;
                    bool convertToRgb = false;
                    int bytesPerPixel = imageFrame.BytesPerPixel;

                    if (imageFrame.Format == ColorImageFormat.RawBayerResolution640x480Fps30 ||
                        imageFrame.Format == ColorImageFormat.RawBayerResolution1280x960Fps12)
                    {
                        convertToRgb = true;
                        bytesPerPixel = 4;
                    }

                    if (haveNewFormat)
                    {
                        if (convertToRgb)
                        {
                            this._rawPixelData = new byte[imageFrame.PixelDataLength];
                            this._pixelData = new byte[bytesPerPixel * imageFrame.Width * imageFrame.Height];
                        }
                        else
                        {
                            this._pixelData = new byte[imageFrame.PixelDataLength];
                        }
                    }

                    if (convertToRgb)
                    {
                        imageFrame.CopyPixelDataTo(this._rawPixelData);
                        ConvertBayerToRgb32(imageFrame.Width, imageFrame.Height);
                    }
                    else
                    {
                        imageFrame.CopyPixelDataTo(this._pixelData);
                    }

                    // A WriteableBitmap is a WPF construct that enables resetting the Bits of the image.
                    // This is more efficient than creating a new Bitmap every frame.
                    if (haveNewFormat)
                    {
                        PixelFormat format = PixelFormats.Bgr32;
                        if (imageFrame.Format == ColorImageFormat.InfraredResolution640x480Fps30)
                        {
                            format = PixelFormats.Gray16;
                        }

                        this.View = new WriteableBitmap(
                            imageFrame.Width,
                            imageFrame.Height,
                            96,  // DpiX
                            96,  // DpiY
                            format,
                            null);

                    }

                    this.View.WritePixels(
                        new Int32Rect(0, 0, imageFrame.Width, imageFrame.Height),
                        this._pixelData,
                        imageFrame.Width * bytesPerPixel,
                        0);

                    this._lastImageFormat = imageFrame.Format;
                }
            }
        }
    }
}
