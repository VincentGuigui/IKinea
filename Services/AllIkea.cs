namespace Ikinea.Rest
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ikea.com/v1.0")]
    [System.Xml.Serialization.XmlRootAttribute("ikea-rest", Namespace = "http://www.ikea.com/v1.0", IsNullable = false)]
    public partial class ikearest
    {

        private header headerField;

        private productsProduct[] productsField;

        private decimal versionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public header header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace = "")]
        [System.Xml.Serialization.XmlArrayItemAttribute("product", IsNullable = false)]
        public productsProduct[] products
        {
            get
            {
                return this.productsField;
            }
            set
            {
                this.productsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class header
    {

        private string requestCommandField;

        private string responseTypeField;

        private string[] datasetsField;

        /// <remarks/>
        public string requestCommand
        {
            get
            {
                return this.requestCommandField;
            }
            set
            {
                this.requestCommandField = value;
            }
        }

        /// <remarks/>
        public string responseType
        {
            get
            {
                return this.responseTypeField;
            }
            set
            {
                this.responseTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("dataset", IsNullable = false)]
        public string[] datasets
        {
            get
            {
                return this.datasetsField;
            }
            set
            {
                this.datasetsField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProduct
    {

        private string uRLField;

        private bool browseableField;

        private string partNumberField;

        private string nameField;

        private object namesweField;

        private byte numberOfItemsField;

        private productsProductItems itemsField;

        private productsProductCategories categoriesField;

        private productsProductAttribute[] attributesField;

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }

        /// <remarks/>
        public bool browseable
        {
            get
            {
                return this.browseableField;
            }
            set
            {
                this.browseableField = value;
            }
        }

        /// <remarks/>
        public string partNumber
        {
            get
            {
                return this.partNumberField;
            }
            set
            {
                this.partNumberField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public object nameswe
        {
            get
            {
                return this.namesweField;
            }
            set
            {
                this.namesweField = value;
            }
        }

        /// <remarks/>
        public byte numberOfItems
        {
            get
            {
                return this.numberOfItemsField;
            }
            set
            {
                this.numberOfItemsField = value;
            }
        }

        /// <remarks/>
        public productsProductItems items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        public productsProductCategories categories
        {
            get
            {
                return this.categoriesField;
            }
            set
            {
                this.categoriesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("attribute", IsNullable = false)]
        public productsProductAttribute[] attributes
        {
            get
            {
                return this.attributesField;
            }
            set
            {
                this.attributesField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItems
    {

        private productsProductItemsItem itemField;

        /// <remarks/>
        public productsProductItemsItem item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItem
    {

        private string partNumberField;

        private string uRLField;

        private string nameField;

        private bool newField;

        private string factsField;

        private bool btiField;

        private bool buyableField;

        private bool browseableField;
        
        private int portesField;

        private int etageresField;

        private object namesweField;

        private string careInstField;

        private string custBenefitField;

        private string designerField;

        private string environmentField;

        private string goodToKnowField;

        private string custMaterialsField;

        private byte nopackagesField;

        private bool reqAssemblyField;

        private string typeField;

        private string pkgMeasField;

        private string measureField;

        private productsProductItemsItemAttributeItem[] attributesItemsField;

        private productsProductItemsItemImages imagesField;

        private productsProductItemsItemPrices pricesField;

        /// <remarks/>
        public string partNumber
        {
            get
            {
                return this.partNumberField;
            }
            set
            {
                this.partNumberField = value;
            }
        }

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public bool @new
        {
            get
            {
                return this.newField;
            }
            set
            {
                this.newField = value;
            }
        }

        /// <remarks/>
        public string facts
        {
            get
            {
                return this.factsField;
            }
            set
            {
                this.factsField = value;
            }
        }

        /// <remarks/>
        public bool bti
        {
            get
            {
                return this.btiField;
            }
            set
            {
                this.btiField = value;
            }
        }

        /// <remarks/>
        public bool buyable
        {
            get
            {
                return this.buyableField;
            }
            set
            {
                this.buyableField = value;
            }
        }

        /// <remarks/>
        public bool browseable
        {
            get
            {
                return this.browseableField;
            }
            set
            {
                this.browseableField = value;
            }
        }
        /// <remarks/>
        public int portes
        {
            get
            {
                return this.portesField;
            }
            set
            {
                this.portesField = value;
            }
        }
        /// <remarks/>
        public int etageres
        {
            get
            {
                return this.etageresField;
            }
            set
            {
                this.etageresField = value;
            }
        }

        /// <remarks/>
        public object nameswe
        {
            get
            {
                return this.namesweField;
            }
            set
            {
                this.namesweField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string careInst
        {
            get
            {
                return this.careInstField;
            }
            set
            {
                this.careInstField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string custBenefit
        {
            get
            {
                return this.custBenefitField;
            }
            set
            {
                this.custBenefitField = value;
            }
        }

        /// <remarks/>
        public string designer
        {
            get
            {
                return this.designerField;
            }
            set
            {
                this.designerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string environment
        {
            get
            {
                return this.environmentField;
            }
            set
            {
                this.environmentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string goodToKnow
        {
            get
            {
                return this.goodToKnowField;
            }
            set
            {
                this.goodToKnowField = value;
            }
        }

        /// <remarks/>
        public string custMaterials
        {
            get
            {
                return this.custMaterialsField;
            }
            set
            {
                this.custMaterialsField = value;
            }
        }

        /// <remarks/>
        public byte nopackages
        {
            get
            {
                return this.nopackagesField;
            }
            set
            {
                this.nopackagesField = value;
            }
        }

        /// <remarks/>
        public bool reqAssembly
        {
            get
            {
                return this.reqAssemblyField;
            }
            set
            {
                this.reqAssemblyField = value;
            }
        }

        /// <remarks/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string pkgMeas
        {
            get
            {
                return this.pkgMeasField;
            }
            set
            {
                this.pkgMeasField = value;
            }
        }

        /// <remarks/>
        public string measure
        {
            get
            {
                return this.measureField;
            }
            set
            {
                this.measureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("attributeItem", IsNullable = false)]
        public productsProductItemsItemAttributeItem[] attributesItems
        {
            get
            {
                return this.attributesItemsField;
            }
            set
            {
                this.attributesItemsField = value;
            }
        }

        /// <remarks/>
        public productsProductItemsItemImages images
        {
            get
            {
                return this.imagesField;
            }
            set
            {
                this.imagesField = value;
            }
        }

        /// <remarks/>
        public productsProductItemsItemPrices prices
        {
            get
            {
                return this.pricesField;
            }
            set
            {
                this.pricesField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemAttributeItem
    {

        private string valueField;

        private string nameField;

        /// <remarks/>
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemImages
    {

        private productsProductItemsItemImagesSmall smallField;

        private productsProductItemsItemImagesThumb thumbField;

        private productsProductItemsItemImagesImage[] normalField;

        private productsProductItemsItemImagesImage1[] largeField;

        private productsProductItemsItemImagesImage2[] zoomField;

        /// <remarks/>
        public productsProductItemsItemImagesSmall small
        {
            get
            {
                return this.smallField;
            }
            set
            {
                this.smallField = value;
            }
        }

        /// <remarks/>
        public productsProductItemsItemImagesThumb thumb
        {
            get
            {
                return this.thumbField;
            }
            set
            {
                this.thumbField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("image", IsNullable = false)]
        public productsProductItemsItemImagesImage[] normal
        {
            get
            {
                return this.normalField;
            }
            set
            {
                this.normalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("image", IsNullable = false)]
        public productsProductItemsItemImagesImage1[] large
        {
            get
            {
                return this.largeField;
            }
            set
            {
                this.largeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("image", IsNullable = false)]
        public productsProductItemsItemImagesImage2[] zoom
        {
            get
            {
                return this.zoomField;
            }
            set
            {
                this.zoomField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemImagesSmall
    {

        private productsProductItemsItemImagesSmallImage imageField;

        /// <remarks/>
        public productsProductItemsItemImagesSmallImage image
        {
            get
            {
                return this.imageField;
            }
            set
            {
                this.imageField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemImagesSmallImage
    {

        private byte heightField;

        private byte widthField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemImagesThumb
    {

        private productsProductItemsItemImagesThumbImage imageField;

        /// <remarks/>
        public productsProductItemsItemImagesThumbImage image
        {
            get
            {
                return this.imageField;
            }
            set
            {
                this.imageField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemImagesThumbImage
    {

        private byte heightField;

        private byte widthField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemImagesImage
    {

        private byte heightField;

        private byte widthField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemImagesImage1
    {

        private ushort heightField;

        private ushort widthField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemImagesImage2
    {

        private ushort heightField;

        private ushort widthField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemPrices
    {

        private productsProductItemsItemPricesNormal normalField;

        private productsProductItemsItemPricesSecond secondField;

        private productsProductItemsItemPricesFamilynormal familynormalField;

        private productsProductItemsItemPricesFamilysecond familysecondField;

        /// <remarks/>
        public productsProductItemsItemPricesNormal normal
        {
            get
            {
                return this.normalField;
            }
            set
            {
                this.normalField = value;
            }
        }

        /// <remarks/>
        public productsProductItemsItemPricesSecond second
        {
            get
            {
                return this.secondField;
            }
            set
            {
                this.secondField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("family-normal")]
        public productsProductItemsItemPricesFamilynormal familynormal
        {
            get
            {
                return this.familynormalField;
            }
            set
            {
                this.familynormalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("family-second")]
        public productsProductItemsItemPricesFamilysecond familysecond
        {
            get
            {
                return this.familysecondField;
            }
            set
            {
                this.familysecondField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemPricesNormal
    {

        private productsProductItemsItemPricesNormalPriceNormal priceNormalField;

        private object pricePreviousField;

        private object priceNormalPerUnitField;

        private object pricePreviousPerUnitField;

        /// <remarks/>
        public productsProductItemsItemPricesNormalPriceNormal priceNormal
        {
            get
            {
                return this.priceNormalField;
            }
            set
            {
                this.priceNormalField = value;
            }
        }

        /// <remarks/>
        public object pricePrevious
        {
            get
            {
                return this.pricePreviousField;
            }
            set
            {
                this.pricePreviousField = value;
            }
        }

        /// <remarks/>
        public object priceNormalPerUnit
        {
            get
            {
                return this.priceNormalPerUnitField;
            }
            set
            {
                this.priceNormalPerUnitField = value;
            }
        }

        /// <remarks/>
        public object pricePreviousPerUnit
        {
            get
            {
                return this.pricePreviousPerUnitField;
            }
            set
            {
                this.pricePreviousPerUnitField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemPricesNormalPriceNormal
    {

        private decimal unformattedField;

        private string perUnitField;

        private decimal prfChargeField;

        private bool prfChargeFieldSpecified;

        private string prfChargeFormattedField;

        private decimal priceWithNoPrfChargeField;

        private bool priceWithNoPrfChargeFieldSpecified;

        private string priceWithNoPrfChargeFormattedField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal unformatted
        {
            get
            {
                return this.unformattedField;
            }
            set
            {
                this.unformattedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string perUnit
        {
            get
            {
                return this.perUnitField;
            }
            set
            {
                this.perUnitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal prfCharge
        {
            get
            {
                return this.prfChargeField;
            }
            set
            {
                this.prfChargeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool prfChargeSpecified
        {
            get
            {
                return this.prfChargeFieldSpecified;
            }
            set
            {
                this.prfChargeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string prfChargeFormatted
        {
            get
            {
                return this.prfChargeFormattedField;
            }
            set
            {
                this.prfChargeFormattedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal priceWithNoPrfCharge
        {
            get
            {
                return this.priceWithNoPrfChargeField;
            }
            set
            {
                this.priceWithNoPrfChargeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool priceWithNoPrfChargeSpecified
        {
            get
            {
                return this.priceWithNoPrfChargeFieldSpecified;
            }
            set
            {
                this.priceWithNoPrfChargeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string priceWithNoPrfChargeFormatted
        {
            get
            {
                return this.priceWithNoPrfChargeFormattedField;
            }
            set
            {
                this.priceWithNoPrfChargeFormattedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemPricesSecond
    {

        private productsProductItemsItemPricesSecondPriceNormal priceNormalField;

        private object priceChangedField;

        private object priceNormalPerUnitField;

        private object priceChangedPerUnitField;

        /// <remarks/>
        public productsProductItemsItemPricesSecondPriceNormal priceNormal
        {
            get
            {
                return this.priceNormalField;
            }
            set
            {
                this.priceNormalField = value;
            }
        }

        /// <remarks/>
        public object priceChanged
        {
            get
            {
                return this.priceChangedField;
            }
            set
            {
                this.priceChangedField = value;
            }
        }

        /// <remarks/>
        public object priceNormalPerUnit
        {
            get
            {
                return this.priceNormalPerUnitField;
            }
            set
            {
                this.priceNormalPerUnitField = value;
            }
        }

        /// <remarks/>
        public object priceChangedPerUnit
        {
            get
            {
                return this.priceChangedPerUnitField;
            }
            set
            {
                this.priceChangedPerUnitField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemPricesSecondPriceNormal
    {

        private decimal prfChargeField;

        private bool prfChargeFieldSpecified;

        private string prfChargeFormattedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal prfCharge
        {
            get
            {
                return this.prfChargeField;
            }
            set
            {
                this.prfChargeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool prfChargeSpecified
        {
            get
            {
                return this.prfChargeFieldSpecified;
            }
            set
            {
                this.prfChargeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string prfChargeFormatted
        {
            get
            {
                return this.prfChargeFormattedField;
            }
            set
            {
                this.prfChargeFormattedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemPricesFamilynormal
    {

        private productsProductItemsItemPricesFamilynormalPriceNormal priceNormalField;

        private object priceChangedField;

        /// <remarks/>
        public productsProductItemsItemPricesFamilynormalPriceNormal priceNormal
        {
            get
            {
                return this.priceNormalField;
            }
            set
            {
                this.priceNormalField = value;
            }
        }

        /// <remarks/>
        public object priceChanged
        {
            get
            {
                return this.priceChangedField;
            }
            set
            {
                this.priceChangedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemPricesFamilynormalPriceNormal
    {

        private decimal prfChargeField;

        private bool prfChargeFieldSpecified;

        private string prfChargeFormattedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal prfCharge
        {
            get
            {
                return this.prfChargeField;
            }
            set
            {
                this.prfChargeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool prfChargeSpecified
        {
            get
            {
                return this.prfChargeFieldSpecified;
            }
            set
            {
                this.prfChargeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string prfChargeFormatted
        {
            get
            {
                return this.prfChargeFormattedField;
            }
            set
            {
                this.prfChargeFormattedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemPricesFamilysecond
    {

        private productsProductItemsItemPricesFamilysecondPriceNormal priceNormalField;

        private object priceChangedField;

        /// <remarks/>
        public productsProductItemsItemPricesFamilysecondPriceNormal priceNormal
        {
            get
            {
                return this.priceNormalField;
            }
            set
            {
                this.priceNormalField = value;
            }
        }

        /// <remarks/>
        public object priceChanged
        {
            get
            {
                return this.priceChangedField;
            }
            set
            {
                this.priceChangedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductItemsItemPricesFamilysecondPriceNormal
    {

        private decimal prfChargeField;

        private bool prfChargeFieldSpecified;

        private string prfChargeFormattedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal prfCharge
        {
            get
            {
                return this.prfChargeField;
            }
            set
            {
                this.prfChargeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool prfChargeSpecified
        {
            get
            {
                return this.prfChargeFieldSpecified;
            }
            set
            {
                this.prfChargeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string prfChargeFormatted
        {
            get
            {
                return this.prfChargeFormattedField;
            }
            set
            {
                this.prfChargeFormattedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductCategories
    {

        private object collectionsField;

        private productsProductCategoriesSystems systemsField;

        private productsProductCategoriesSeries seriesField;

        private productsProductCategoriesParents parentsField;

        /// <remarks/>
        public object collections
        {
            get
            {
                return this.collectionsField;
            }
            set
            {
                this.collectionsField = value;
            }
        }

        /// <remarks/>
        public productsProductCategoriesSystems systems
        {
            get
            {
                return this.systemsField;
            }
            set
            {
                this.systemsField = value;
            }
        }

        /// <remarks/>
        public productsProductCategoriesSeries series
        {
            get
            {
                return this.seriesField;
            }
            set
            {
                this.seriesField = value;
            }
        }

        /// <remarks/>
        public productsProductCategoriesParents parents
        {
            get
            {
                return this.parentsField;
            }
            set
            {
                this.parentsField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductCategoriesSystems
    {

        private productsProductCategoriesSystemsCategory categoryField;

        /// <remarks/>
        public productsProductCategoriesSystemsCategory category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductCategoriesSystemsCategory
    {

        private ushort identifierField;

        private string catalogIdentifierField;

        private string nameField;

        private string uRLField;

        /// <remarks/>
        public ushort identifier
        {
            get
            {
                return this.identifierField;
            }
            set
            {
                this.identifierField = value;
            }
        }

        /// <remarks/>
        public string catalogIdentifier
        {
            get
            {
                return this.catalogIdentifierField;
            }
            set
            {
                this.catalogIdentifierField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductCategoriesSeries
    {

        private productsProductCategoriesSeriesCategory categoryField;

        /// <remarks/>
        public productsProductCategoriesSeriesCategory category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductCategoriesSeriesCategory
    {

        private ushort identifierField;

        private string catalogIdentifierField;

        private string nameField;

        private string uRLField;

        /// <remarks/>
        public ushort identifier
        {
            get
            {
                return this.identifierField;
            }
            set
            {
                this.identifierField = value;
            }
        }

        /// <remarks/>
        public string catalogIdentifier
        {
            get
            {
                return this.catalogIdentifierField;
            }
            set
            {
                this.catalogIdentifierField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductCategoriesParents
    {

        private productsProductCategoriesParentsCategory categoryField;

        /// <remarks/>
        public productsProductCategoriesParentsCategory category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductCategoriesParentsCategory
    {

        private ushort identifierField;

        private string catalogIdentifierField;

        private string nameField;

        private string uRLField;

        /// <remarks/>
        public ushort identifier
        {
            get
            {
                return this.identifierField;
            }
            set
            {
                this.identifierField = value;
            }
        }

        /// <remarks/>
        public string catalogIdentifier
        {
            get
            {
                return this.catalogIdentifierField;
            }
            set
            {
                this.catalogIdentifierField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProductAttribute
    {

        private string[] valueField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("value")]
        public string[] value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class products
    {

        private productsProduct[] productField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("product")]
        public productsProduct[] product
        {
            get
            {
                return this.productField;
            }
            set
            {
                this.productField = value;
            }
        }
    }

}