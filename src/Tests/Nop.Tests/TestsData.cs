using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Affiliates;
using Nop.Core.Domain.Blogs;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Configuration;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Forums;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Logging;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Messages;
using Nop.Core.Domain.News;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;
using Nop.Core.Domain.Polls;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Tasks;
using Nop.Core.Domain.Tax;
using Nop.Core.Domain.Topics;
using Nop.Core.Domain.Vendors;
using Nop.Services.Messages;

namespace Nop.Tests
{
    public static class TestsData
    {
        public static Affiliate GetAffiliate
        {
            get
            {
                return new Affiliate
                {
                    Deleted = true,
                    Active = true,
                    Address = GetAddress,
                    AdminComment = "AdminComment 1",
                    FriendlyUrlName = "FriendlyUrlName 1"
                };
            }
        }

        public static MemoryCacheManager CacheManager
        {
            get
            {
                var cacheManager = new MemoryCacheManager();
                cacheManager.Set("some_key_1", 3, int.MaxValue);
                cacheManager.Set("some_key_2", 4, int.MaxValue);

                return cacheManager;
            }
        }

        public static Product GetProduct
        {
            get
            {
                return new Product
                {
                    Id = 1,
                    Name = "Product name 1",
                    AvailableStartDateTimeUtc = new DateTime(2010, 01, 01),
                    RequiredProductIds = "1, 4,7 ,a,",
                    AvailableEndDateTimeUtc = new DateTime(2010, 01, 03),
                    CreatedOnUtc = new DateTime(2010, 01, 03),
                    UpdatedOnUtc = new DateTime(2010, 01, 04),
                    ProductType = ProductType.GroupedProduct,
                    ParentGroupedProductId = 2,
                    VisibleIndividually = true,

                    ManageInventoryMethod = ManageInventoryMethod.ManageStock,
                    ShortDescription = "ShortDescription 1",
                    FullDescription = "FullDescription 1",
                    AdminComment = "AdminComment 1",
                    VendorId = 1,
                    ProductTemplateId = 2,
                    ShowOnHomePage = false,
                    MetaKeywords = "Meta keywords",
                    MetaDescription = "Meta description",
                    MetaTitle = "Meta title",
                    AllowCustomerReviews = true,
                    ApprovedRatingSum = 2,
                    NotApprovedRatingSum = 3,
                    ApprovedTotalReviews = 4,
                    NotApprovedTotalReviews = 5,
                    SubjectToAcl = true,
                    LimitedToStores = true,
                    Sku = "sku 1",
                    ManufacturerPartNumber = "manufacturerPartNumber",
                    Gtin = "gtin 1",
                    IsGiftCard = true,
                    GiftCardTypeId = 1,
                    OverriddenGiftCardAmount = 1,
                    IsDownload = true,
                    DownloadId = 2,
                    UnlimitedDownloads = true,
                    MaxNumberOfDownloads = 3,
                    DownloadExpirationDays = 4,
                    DownloadActivationTypeId = 5,
                    HasSampleDownload = true,
                    SampleDownloadId = 6,
                    HasUserAgreement = true,
                    UserAgreementText = "userAgreementText",
                    IsRecurring = true,
                    RecurringCycleLength = 7,
                    RecurringCyclePeriodId = 8,
                    RecurringTotalCycles = 9,
                    IsRental = true,
                    RentalPriceLength = 9,
                    RentalPricePeriodId = 0,
                    IsShipEnabled = true,
                    IsFreeShipping = true,
                    ShipSeparately = true,
                    AdditionalShippingCharge = 10.1M,
                    DeliveryDateId = 5,
                    IsTaxExempt = true,
                    TaxCategoryId = 11,
                    IsTelecommunicationsOrBroadcastingOrElectronicServices = true,
                    ManageInventoryMethodId = 1,
                    UseMultipleWarehouses = true,
                    WarehouseId = 6,
                    StockQuantity = 13,
                    DisplayStockAvailability = true,
                    DisplayStockQuantity = true,
                    MinStockQuantity = 14,
                    LowStockActivityId = 15,
                    NotifyAdminForQuantityBelow = 16,
                    BackorderModeId = 17,
                    AllowBackInStockSubscriptions = true,
                    OrderMinimumQuantity = 18,
                    OrderMaximumQuantity = 19,
                    AllowedQuantities = "1, 5,4,10,sdf",
                    AllowAddingOnlyExistingAttributeCombinations = true,
                    NotReturnable = true,
                    DisableBuyButton = true,
                    DisableWishlistButton = true,
                    AvailableForPreOrder = true,
                    PreOrderAvailabilityStartDateTimeUtc = new DateTime(2010, 01, 01),
                    CallForPrice = true,
                    Price = 21.1M,
                    OldPrice = 22.1M,
                    ProductCost = 23.1M,
                    SpecialPrice = 32.1M,
                    SpecialPriceStartDateTimeUtc = new DateTime(2010, 01, 05),
                    SpecialPriceEndDateTimeUtc = new DateTime(2010, 01, 06),
                    CustomerEntersPrice = true,
                    MinimumCustomerEnteredPrice = 24.1M,
                    MaximumCustomerEnteredPrice = 25.1M,
                    BasepriceEnabled = true,
                    BasepriceAmount = 33.1M,
                    BasepriceUnitId = 4,
                    BasepriceBaseAmount = 34.1M,
                    BasepriceBaseUnitId = 5,
                    MarkAsNew = true,
                    MarkAsNewStartDateTimeUtc = new DateTime(2010, 01, 07),
                    MarkAsNewEndDateTimeUtc = new DateTime(2010, 01, 08),
                    HasTierPrices = true,
                    HasDiscountsApplied = true,
                    Weight = 26.1M,
                    Length = 27.1M,
                    Width = 28.1M,
                    Height = 29.1M,
                    RequireOtherProducts = true,
                    AutomaticallyAddRequiredProducts = true,
                    DisplayOrder = 30,
                    Published = true,
                    Deleted = false
                };
            }
        }

        public static Discount GetDiscount
        {
            get
            {
                return new Discount
                {
                    DiscountType = DiscountType.AssignedToCategories,
                    Name = "Discount 1",
                    UsePercentage = true,
                    DiscountPercentage = 1.1M,
                    DiscountAmount = 2.1M,
                    MaximumDiscountAmount = 3.1M,
                    StartDateUtc = new DateTime(2010, 01, 01),
                    EndDateUtc = new DateTime(2010, 01, 02),
                    RequiresCouponCode = true,
                    CouponCode = "SecretCode",
                    IsCumulative = true,
                    DiscountLimitation = DiscountLimitationType.Unlimited,
                    LimitationTimes = 3,
                    MaximumDiscountedQuantity = 4,
                    AppliedToSubCategories = true
                };
            }
        }

        public static GenericAttribute CreateGenericAttribute(int entityId, string value, string key = null)
        {
            key = key ?? SystemCustomerAttributeNames.DiscountCouponCode;
            return new GenericAttribute
            {
                EntityId = entityId,
                Key = key,
                KeyGroup = "Customer",
                Value = value
            };
        }

        public static ForumGroup GetForumGroup
        {
            get
            {
                return new ForumGroup
                {
                    Name = "Forum Group 1",
                    DisplayOrder = 1,
                    CreatedOnUtc = new DateTime(2010, 01, 01),
                    UpdatedOnUtc = new DateTime(2010, 01, 02),
                };
            }
        }

        public static Forum GetForum(ForumGroup forumGroup=null)
        {
           
                var forum = new Forum
                {
                    Name = "Forum 1",
                    Description = "Forum 1 Description",
                    DisplayOrder = 10,
                    CreatedOnUtc = new DateTime(2010, 01, 01),
                    UpdatedOnUtc = new DateTime(2010, 01, 02),
                    NumPosts = 25,
                    NumTopics = 15
                };

            if (forumGroup != null)
            {
                forum.ForumGroup = forumGroup;
                forum.ForumGroupId = forumGroup.Id;
            }

            return forum;
        }

        public static Download GeDownload
        {
            get
            {
                return new Download
                {
                    DownloadGuid = Guid.NewGuid(),
                    UseDownloadUrl = true,
                    DownloadUrl = "http://www.someUrl.com/file.zip",
                    DownloadBinary = new byte[] { 1, 2, 3 },
                    ContentType = MimeTypes.ApplicationXZipCo,
                    Filename = "file",
                    Extension = ".zip",
                    IsNew = true
                };
            }
        }

        public static DeliveryDate GetDeliveryDate
        {
            get
            {
                return new DeliveryDate
                {
                    Name = "Name 1",
                    DisplayOrder = 1
                };
            }
        }

        public static ShipmentItem GetShipmentItem
        {
            get
            {
                return new ShipmentItem
                {
                    OrderItemId = 2,
                    Quantity = 3,
                    WarehouseId = 4,
                };
            }
        }

        public static ForumSubscription GetForumSubscription(Customer customer, Forum forum=null)
        {
            var forumSubscription = new ForumSubscription
            {
                CreatedOnUtc = DateTime.UtcNow,
                SubscriptionGuid = new Guid("11111111-2222-3333-4444-555555555555")
            };

            if (customer != null)
                forumSubscription.CustomerId = customer.Id;
            if (forum != null)
                forumSubscription.ForumId = forum.Id;

            return forumSubscription;
        }

        public static ForumTopic GetForumTopic(Customer customer, Forum forum)
        {
            var forumTopic = new ForumTopic
            {
                Subject = "Forum Topic 1",
                TopicTypeId = (int) ForumTopicType.Sticky,
                Views = 123,
                CreatedOnUtc = new DateTime(2010, 01, 01),
                UpdatedOnUtc = new DateTime(2010, 01, 02),
                NumPosts = 100
            };

            if (customer != null)
                forumTopic.CustomerId = customer.Id;
            if (forum != null)
                forumTopic.ForumId = forum.Id;

            return forumTopic;
        }

        public static ForumPost GetForumPost(ForumTopic forumTopic, Customer customer)
        {
            var forumPost = new ForumPost
            {
                Text = "Forum Post 1 Text",
                IPAddress = "127.0.0.1",
                CreatedOnUtc = new DateTime(2010, 01, 01),
                UpdatedOnUtc = new DateTime(2010, 01, 02),
            };

            if (forumTopic != null)
            {
                forumPost.ForumTopic = forumTopic;
                forumPost.TopicId = forumTopic.Id;
            }

            if (customer != null)
                forumPost.CustomerId = customer.Id;

            return forumPost;
        }

        public static DiscountUsageHistory GetDiscountUsageHistory
        {
            get
            {
                return new DiscountUsageHistory
                {
                    Discount = GetDiscount,
                    CreatedOnUtc = new DateTime(2010, 01, 01)
                };
            }
        }

        public static DiscountRequirement GetDiscountRequirement
        {
            get
            {
                return new DiscountRequirement
                {
                    DiscountRequirementRuleSystemName = "BillingCountryIs"
                };
            }
        }

        public static Currency GetCurrency
        {
            get { return CreateCurrency(customFormatting: "€0.00"); }
        }

        public static Currency CreateCurrency(int id = 1, string name = "US Dollar", string currencyCode = "USD", decimal rate = 1.1M, string displayLocale = "en-US", string customFormatting = "")
        {
            return new Currency
            {
                Id=id,
                Name = name,
                CurrencyCode = currencyCode,
                Rate = rate,
                DisplayLocale = displayLocale,
                CustomFormatting = customFormatting,
                LimitedToStores = true,
                Published = true,
                DisplayOrder = 2,
                CreatedOnUtc = new DateTime(2010, 01, 01),
                UpdatedOnUtc = new DateTime(2010, 01, 02)
            };
        }

        public static MeasureDimension GetMeasureDimension
        {
            get
            {
                return new MeasureDimension
                {
                    Name = "inch(es)",
                    SystemKeyword = "inches",
                    Ratio = 1.12345678M,
                    DisplayOrder = 2
                };
            }
        }

        public static IList<MeasureDimension> CreateMeasureDimensions(params decimal[] ratios)
        {
            var measureDimensions = new List<MeasureDimension>();

            var id = 1;

            measureDimensions.AddRange(ratios.Select(r=>new MeasureDimension
            {
                Id = id,
                DisplayOrder = id++,
                Ratio = r
            }));

            return measureDimensions;
        }

        public static IList<MeasureWeight> CreateMeasureWeights(params decimal[] ratios)
        {
            var measureWeights = new List<MeasureWeight>();

            var id = 1;

            measureWeights.AddRange(ratios.Select(r => new MeasureWeight
            {
                Id = id,
                DisplayOrder = id++,
                Ratio = r
            }));

            return measureWeights;
        }

        public static MeasureWeight GetMeasureWeight
        {
            get
            {
                return new MeasureWeight
                {
                    Name = "ounce(s)",
                    SystemKeyword = "ounce",
                    Ratio = 1.12345678M,
                    DisplayOrder = 2,
                };
            }
        }
        
        public static AddressAttribute GetAddressAttribute(bool addAddressAttributeValues = true)
        {
            var addressAttribute = new AddressAttribute
            {
                Name = "Name 1",
                IsRequired = true,
                AttributeControlType = AttributeControlType.Datepicker,
                DisplayOrder = 2
            };

            if (addAddressAttributeValues)
                addressAttribute.AddressAttributeValues.Add(GetAddressAttributeValue());

            return addressAttribute;

        }

        public static AddressAttributeValue GetAddressAttributeValue(bool setAddressAttribute = false)
        {
            var addess = new AddressAttributeValue
            {
                Name = "Name 2",
                IsPreSelected = true,
                DisplayOrder = 1
            };

            if (setAddressAttribute)
                addess.AddressAttribute = GetAddressAttribute(false);

            return addess;
        }

        public static TierPrice GeTierPrice
        {
            get
            {
                return CreateTierPrice(GetProduct, GetCustomerRole("Administrators"));
            }
        }

        public static TierPrice CreateTierPrice(Product product = null, CustomerRole customerRole = null, decimal price = 2.1M, int quantity = 1, int id = 1)
        {
            var tierPrice = new TierPrice
            {
                Id = id,
                StoreId = 1,
                Quantity = quantity,
                Price = price
            };

            if (product != null)
                tierPrice.Product = product;

            if (customerRole != null)
                tierPrice.CustomerRole = customerRole;

            return tierPrice;
        }

        public static UrlRecord GetUrlRecord
        {
            get
            {
                return new UrlRecord
                {
                    EntityId = 1,
                    EntityName = "EntityName 1",
                    Slug = "Slug 1",
                    LanguageId = 2
                };
            }
        }

        public static Picture GetPicture
        {
            get
            {
                return new Picture
                {
                    PictureBinary = new byte[] {1, 2, 3},
                    MimeType = MimeTypes.ImagePJpeg,
                    IsNew = true,
                    SeoFilename = "seo filename 1",
                    AltAttribute = "AltAttribute 1",
                    TitleAttribute = "TitleAttribute 1"
                };
            }
        }

        public static Campaign GetCampaign
        {
            get
            {
                return new Campaign
                {
                    Name = "Name 1",
                    Subject = "Subject 1",
                    Body = "Body 1",
                    CreatedOnUtc = new DateTime(2010, 01, 02),
                    DontSendBeforeDateUtc = new DateTime(2016, 2, 23),
                    CustomerRoleId = 1,
                    StoreId = 1
                };
            }
        }

        public static EmailAccount GetEmailAccount
        {
            get
            {
                return new EmailAccount
                {
                    Email = "admin@yourstore.com",
                    DisplayName = "Administrator",
                    Host = "127.0.0.1",
                    Port = 125,
                    Username = "John",
                    Password = "111",
                    EnableSsl = true,
                    UseDefaultCredentials = true
                };
            }
        }

        public static MessageTemplate GetMessageTemplate
        {
            get
            {
                return new MessageTemplate
                {
                    Name = "Template1",
                    BccEmailAddresses = "Bcc",
                    Subject = "Subj",
                    Body = "Some text",
                    IsActive = true,
                    AttachedDownloadId = 3,
                    EmailAccountId = 1,
                    LimitedToStores = true,
                    DelayBeforeSend = 2,
                    DelayPeriodId = 0
                };
            }
        }

        public static NewsLetterSubscription GetNewsLetterSubscription
        {
            get
            {
                return new NewsLetterSubscription
                {
                    Email = "me@yourstore.com",
                    NewsLetterSubscriptionGuid = Guid.NewGuid(),
                    CreatedOnUtc = new DateTime(2010, 01, 01),
                    StoreId = 1,
                    Active = true
                };
            }
        }

        public static QueuedEmail GetQueuedEmail
        {
            get
            {
                return new QueuedEmail
                {
                    PriorityId = 5,
                    From = "From",
                    FromName = "FromName",
                    To = "To",
                    ToName = "ToName",
                    ReplyTo = "ReplyTo",
                    ReplyToName = "ReplyToName",
                    CC = "CC",
                    Bcc = "Bcc",
                    Subject = "Subject",
                    Body = "Body",
                    AttachmentFilePath = "some file path",
                    AttachmentFileName = "some file name",
                    AttachedDownloadId = 3,
                    CreatedOnUtc = new DateTime(2010, 01, 01),
                    SentTries = 5,
                    SentOnUtc = new DateTime(2010, 02, 02),
                    DontSendBeforeDateUtc = new DateTime(2016, 2, 23)
                };
            }
        }

        public static NewsItem GetNewsItem
        {
            get
            {
                return new NewsItem
                {
                    Title = "Title 1",
                    Short = "Short 1",
                    Full = "Full 1",
                    Published = true,
                    StartDateUtc = new DateTime(2010, 01, 01),
                    EndDateUtc = new DateTime(2010, 01, 02),
                    AllowComments = true,
                    CommentCount = 1,
                    LimitedToStores = true,
                    CreatedOnUtc = new DateTime(2010, 01, 03),
                    MetaTitle = "MetaTitle 1",
                    MetaDescription = "MetaDescription 1",
                    MetaKeywords = "MetaKeywords 1"
                };
            }
        }

        public static CheckoutAttribute GetCheckoutAttribute(int id = 1, bool shippableProductRequired = true)
        {
            return new CheckoutAttribute
            {
                Id = id,
                Name = "Name 1",
                TextPrompt = "TextPrompt 1",
                IsRequired = true,
                ShippableProductRequired = shippableProductRequired,
                IsTaxExempt = true,
                TaxCategoryId = 1,
                AttributeControlType = AttributeControlType.Datepicker,
                DisplayOrder = 2,
                LimitedToStores = true,
                ValidationMinLength = 3,
                ValidationMaxLength = 4,
                ValidationFileAllowedExtensions = "ValidationFileAllowedExtensions 1",
                ValidationFileMaximumSize = 5,
                DefaultValue = "DefaultValue 1",
                ConditionAttributeXml = "ConditionAttributeXml 1"
            };
        }

        public static CheckoutAttributeValue GetCheckoutAttributeValue(int id = 1, string name = "Name 2", CheckoutAttribute checkoutAttribute=null)
        {
            var checkoutAttributeValue = new CheckoutAttributeValue
            {
                Id = id,
                Name = name,
                PriceAdjustment = 1,
                WeightAdjustment = 2,
                IsPreSelected = true,
                DisplayOrder = 3,
                ColorSquaresRgb = "#112233"
            };

            if (checkoutAttribute != null)
            {
                checkoutAttributeValue.CheckoutAttribute = checkoutAttribute;
                checkoutAttributeValue.CheckoutAttributeId = checkoutAttribute.Id;
            }

            return checkoutAttributeValue;
        }

        public static NewsComment GetNewsComment
        {
            get
            {
                return new NewsComment
                {
                    CommentText = "Comment text 1",
                    CreatedOnUtc = new DateTime(2010, 01, 03),
                    Customer = GetCustomer()
                };
            }
        }

        public static ProductPicture GetProductPicture
        {
            get
            {
                return new ProductPicture
                {
                    DisplayOrder = 1,
                    Product = GetProduct,
                    Picture = GetPicture
                };
            }
        }

        public static SpecificationAttribute GetSpecificationAttribute
        {
            get
            {
                return new SpecificationAttribute
                {
                    Name = "SpecificationAttribute name 1",
                    DisplayOrder = 2
                };
            }
        }

        public static SpecificationAttributeOption GetSpecificationAttributeOption(bool setSpecificationAttribute = true)
        {
            var specificationAttributeOption = new SpecificationAttributeOption
            {
                Name = "SpecificationAttributeOption name 1",
                DisplayOrder = 1,
                ColorSquaresRgb = "ColorSquaresRgb 2",

            };

            if (setSpecificationAttribute)
                specificationAttributeOption.SpecificationAttribute = GetSpecificationAttribute;

            return specificationAttributeOption;
        }

        public static ProductTag GetProductTag
        {
            get
            {
                return new ProductTag
                {
                    Name = "Name 1",
                };
            }
        }

        public static ProductTemplate GetProductTemplate
        {
            get
            {
                return new ProductTemplate
                {
                    Name = "Name 1",
                    ViewPath = "ViewPath 1",
                    DisplayOrder = 1,
                };
            }
        }

        public static Warehouse GetWarehouse
        {
            get
            {
                return new Warehouse
                {
                    Name = "Name 2",
                    AddressId = 1,

                    AdminComment = "AdminComment 1"
                };
            }
        }

        public static StoreMapping GetStoreMapping
        {
            get
            {
                return new StoreMapping
                {
                    EntityId = 1,
                    EntityName = "EntityName 1",
                    Store = GetStore,
                };
            }
        }

        public static ProductWarehouseInventory GetProductWarehouseInventory(Product product = null, Warehouse warehouse = null, int warehouseId = 0, int stockQuantity = 3)
        {
            product = product ?? GetProduct;

            var productWarehouseInventory = new ProductWarehouseInventory
            {
                Product = product,
                
                StockQuantity = stockQuantity,
                ReservedQuantity = 4
            };

            if (warehouseId == 0)
            {
                warehouse = warehouse ?? GetWarehouse;
                productWarehouseInventory.Warehouse = warehouse;
                productWarehouseInventory.WarehouseId = warehouse.Id;
            }
            else
            {
                productWarehouseInventory.WarehouseId = warehouseId;
                if(warehouse != null)
                    productWarehouseInventory.Warehouse = warehouse;
            }

            return productWarehouseInventory;
        }

        public static ProductSpecificationAttribute GetProductSpecificationAttribute
        {
            get
            {
                return new ProductSpecificationAttribute
                {
                    AttributeType = SpecificationAttributeType.Hyperlink,
                    AllowFiltering = true,
                    ShowOnProductPage = true,
                    DisplayOrder = 1,
                    Product = GetProduct,
                    SpecificationAttributeOption = GetSpecificationAttributeOption()
                };
            }
        }

        public static ProductManufacturer GetProductManufacturer
        {
            get
            {
                return new ProductManufacturer
                {
                    IsFeaturedProduct = true,
                    DisplayOrder = 1,
                    Product = GetProduct,
                    Manufacturer = GetManufacturer
                };
            }
        }
        
        static int _id = 1;

        public static Country GetCountry
        {
            get
            {
                return new Country
                {
                    Id=_id++,
                    Name = "United States",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    TwoLetterIsoCode = "US",
                    ThreeLetterIsoCode = "USA",
                    NumericIsoCode = 1,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 1,
                    LimitedToStores = true
                };
            }
        }

        public static StateProvince GetStateProvince
        {
            get
            {
                return new StateProvince
                {
                    Name = "Louisiana",
                    Abbreviation = "LA",
                    DisplayOrder = 1,
                    Published = true
                };
            }
        }

        public static ShippingMethod GetShippingMethod
        {
            get
            {
                return new ShippingMethod
                {
                    Name = "By train",
                    Description = "Description 1",
                    DisplayOrder = 1
                };
            }
        }

        public static Address GetAddress
        {
            get
            {
                var country = GetCountry;
                var state = GetStateProvince;
                state.CountryId = country.Id;
                return new Address
                {
                    FirstName = "FirstName 1",
                    LastName = "LastName 1",
                    Email = "Email 1",
                    Company = "Company 1",
                    Country = country,
                    StateProvince =  state,
                    City = "City 1",
                    Address1 = "Address1",
                    Address2 = "Address2",
                    ZipPostalCode = "ZipPostalCode 1",
                    PhoneNumber = "PhoneNumber 1",
                    FaxNumber = "FaxNumber 1",
                    CreatedOnUtc = new DateTime(2010, 01, 01),
                    CustomAttributes = "CustomAttributes 1"
                };
            }
        }

        public static GenericAttribute GetGenericAttribute
        {
            get
            {
                var ga = CreateGenericAttribute(1, "Value 1", "Key 1");
                ga.KeyGroup = "KeyGroup 1";
                ga.StoreId = 2;
                return ga;
            }
        }

        public static CustomerAttributeValue GetCustomerAttributeValue(bool setCustomerAttribute = false)
        {
            var customerAttributeValue = new CustomerAttributeValue
            {
                Name = "Name 2",
                IsPreSelected = true,
                DisplayOrder = 1,
            };

            if (setCustomerAttribute)
                customerAttributeValue.CustomerAttribute = GetCustomerAttribute(false);

            return customerAttributeValue;
        }

        public static CustomerAttribute GetCustomerAttribute(bool addCustomerAttribute = true)
        {
            var customerAttribute = new CustomerAttribute
            {
                Name = "Name 1",
                IsRequired = true,
                AttributeControlType = AttributeControlType.Datepicker,
                DisplayOrder = 2
            };

            if (addCustomerAttribute)
                customerAttribute.CustomerAttributeValues.Add(GetCustomerAttributeValue());

            return customerAttribute;
        }

        public static SearchTerm GetSearchTerm
        {
            get
            {
                return new SearchTerm
                {
                    Keyword = "Keyword 1",
                    StoreId = 1,
                    Count = 2
                };
            }
        }

        public static Setting GetSetting
        {
            get
            {
                return new Setting
                {
                    Name = "Setting1",
                    Value = "Value1",
                    StoreId = 1
                };
            }
        }

        public static PermissionRecord GetPermissionRecord
        {
            get
            {
                return new PermissionRecord
                {
                    Name = "Name 1",
                    SystemName = "SystemName 2",
                    Category = "Category 4",
                };
            }
        }

        public static Customer GetCustomerByName(string name, string systemNames="", string password = "password", PasswordFormat passwordFormat = PasswordFormat.Clear)
        {
            var customer = systemNames.Any() ? GetCustomer(systemNames) : GetCustomer();

            customer.PasswordFormat = passwordFormat;
            customer.Password = password;
            customer.Username = name + "@test.com";
            customer.Email = customer.Username;

            return customer;
        }

        public static Customer GetCustomer(params string[] systemNames)
        {
            var customer = new Customer
            {
                CustomerGuid = Guid.NewGuid(),
                CreatedOnUtc = new DateTime(2010, 01, 01),
                LastActivityDateUtc = new DateTime(2010, 01, 02),
                AdminComment = "some comment here",
                Active = true,
                Deleted = false,
                Username = "a@b.com",
                Password = "password",
                PasswordFormat = PasswordFormat.Clear,
                PasswordSalt = "",
                Email = "a@b.com",
                IsTaxExempt = true,
                AffiliateId = 1,
                VendorId = 2,
                HasShoppingCartItems = true,
                IsSystemAccount = true,
                SystemName = "SystemName 1",
                LastIpAddress = "192.168.1.1",

                LastLoginDateUtc = new DateTime(2010, 01, 02),
            };

            foreach (var systemName in systemNames)
            {
                customer.CustomerRoles.Add(GetCustomerRole(systemName));
            }

            customer.ShoppingCartItems.Add(GetShoppingCartItem());
            return customer;
        }

        public static CustomerRole GetCustomerRole(string systemName)
        {
            return new CustomerRole
            {
                Active = true,
                Name = systemName.Replace(" system", string.Empty),
                SystemName = systemName,
                FreeShipping = true,
                TaxExempt = true,
                IsSystemRole = true,
                PurchasedWithProductId = 1
            };
        }

        public static Product AddTierPrices(this Product product, decimal price, int quantity, CustomerRole customerRole=null)
        {
            product.TierPrices.Add(CreateTierPrice(product, customerRole, price, quantity));
            return product;
        }

        public static RewardPointsHistory GetRewardPointsHistory
        {
            get
            {
                return new RewardPointsHistory
                {
                    Customer = GetCustomer(),
                    StoreId = 1,
                    Points = 2,
                    Message = "Points for registration",
                    PointsBalance = 3,
                    UsedAmount = 3.1M,
                    CreatedOnUtc = new DateTime(2010, 01, 01)
                };
            }
        }

        public static Order GetOrder
        {
            get
            {
                return new Order
                {
                    OrderGuid = Guid.NewGuid(),
                    Customer = GetCustomer(),
                    BillingAddress = GetAddress,
                    Deleted = false,
                    CreatedOnUtc = new DateTime(2010, 01, 01),
                    StoreId = 1,
                    OrderStatus = OrderStatus.Complete,
                    ShippingStatus = ShippingStatus.Shipped,
                    PaymentStatus = PaymentStatus.Paid,
                    PaymentMethodSystemName = "PaymentMethodSystemName1",
                    CustomerCurrencyCode = "RUR",
                    CurrencyRate = 1.1M,
                    CustomerTaxDisplayType = TaxDisplayType.ExcludingTax,
                    VatNumber = "123456789",
                    OrderSubtotalInclTax = 2.1M,
                    OrderSubtotalExclTax = 3.1M,
                    OrderSubTotalDiscountInclTax = 4.1M,
                    OrderSubTotalDiscountExclTax = 5.1M,
                    OrderShippingInclTax = 6.1M,
                    OrderShippingExclTax = 7.1M,
                    PaymentMethodAdditionalFeeInclTax = 8.1M,
                    PaymentMethodAdditionalFeeExclTax = 9.1M,
                    TaxRates = "1,3,5,7",
                    OrderTax = 10.1M,
                    OrderDiscount = 11.1M,
                    OrderTotal = 12.1M,
                    RefundedAmount = 13.1M,
                    RewardPointsWereAdded = true,
                    CheckoutAttributeDescription = "CheckoutAttributeDescription1",
                    CheckoutAttributesXml = "CheckoutAttributesXml1",
                    CustomerLanguageId = 14,
                    CustomerIp = "CustomerIp1",
                    AllowStoringCreditCardNumber = true,
                    CardType = "Visa",
                    CardName = "John Smith",
                    CardNumber = "4111111111111111",
                    MaskedCreditCardNumber = "************1111",
                    CardCvv2 = "123",
                    CardExpirationMonth = "12",
                    CardExpirationYear = "2010",
                    AuthorizationTransactionId = "AuthorizationTransactionId1",
                    AuthorizationTransactionCode = "AuthorizationTransactionCode1",
                    AuthorizationTransactionResult = "AuthorizationTransactionResult1",
                    CaptureTransactionId = "CaptureTransactionId1",
                    CaptureTransactionResult = "CaptureTransactionResult1",
                    SubscriptionTransactionId = "SubscriptionTransactionId1",
                    PaidDateUtc = new DateTime(2010, 01, 01),
                    ShippingAddress = null,
                    PickupAddress = GetAddress,
                    ShippingMethod = "ShippingMethod1",
                    ShippingRateComputationMethodSystemName = "ShippingRateComputationMethodSystemName1",
                    PickUpInStore = true,
                    CustomValuesXml = "CustomValuesXml1"
                };
            }
        }

       public static ShoppingCartItem GetShoppingCartItem(Product product = null, Customer customer=null)
       {
           return new ShoppingCartItem
           {
               ShoppingCartType = ShoppingCartType.ShoppingCart,
               AttributesXml = "AttributesXml 1",
               CustomerEnteredPrice = 1,
               Quantity = 2,
               CreatedOnUtc = new DateTime(2010, 01, 01),
               UpdatedOnUtc = new DateTime(2010, 01, 02),
               Product = product ?? GetProduct,
               Customer = customer,
               StoreId = 1,
               RentalStartDateUtc = new DateTime(2010, 01, 03),
               RentalEndDateUtc = new DateTime(2010, 01, 04)
           };
       }

        public static ShoppingCartItem GetShoppingCartItem(int quantity, decimal additionalShippingCharge, bool IsShipEnabled = true, Customer customer = null)
        {
            customer = customer ?? new Customer();
            var shoppingCartItem = GetShoppingCartItem(new Product
            {
                IsShipEnabled = IsShipEnabled,
                IsFreeShipping = false,
                AdditionalShippingCharge = additionalShippingCharge
            }, customer);

            shoppingCartItem.Quantity = quantity;

            return shoppingCartItem;
        }

        public static Poll GetPoll
        {
            get
            {
                return new Poll
                {
                    Name = "Name 1",
                    SystemKeyword = "SystemKeyword 1",
                    Published = true,
                    ShowOnHomePage = true,
                    DisplayOrder = 1,
                    StartDateUtc = new DateTime(2010, 01, 01),
                    EndDateUtc = new DateTime(2010, 01, 02),
                    Language = GetLanguage
                };
            }
        }

        public static AclRecord GetAclRecord
        {
            get
            {
                return new AclRecord
                {
                    EntityId = 1,
                    EntityName = "EntityName 1",
                    CustomerRole = GetCustomerRole("Administrators")
                };
            }
        }

        public static PollAnswer GetPollAnswer
        {
            get
            {
                return new PollAnswer
                {
                    Name = "Answer 1",
                    NumberOfVotes = 1,
                    DisplayOrder = 2,
                };
            }
        }

        public static PollVotingRecord GetPollVotingRecord
        {
            get
            {
                return new PollVotingRecord
                {
                    Customer = GetCustomer(),
                    CreatedOnUtc = DateTime.UtcNow
                };
            }
        }


        public static ExternalAuthenticationRecord GetExternalAuthenticationRecord
        {
            get
            {
                return new ExternalAuthenticationRecord
                {
                    ExternalIdentifier = "ExternalIdentifier 1",
                    ExternalDisplayIdentifier = "ExternalDisplayIdentifier 1",
                    OAuthToken = "OAuthToken 1",
                    OAuthAccessToken = "OAuthAccessToken 1",
                    ProviderSystemName = "ProviderSystemName 1",
                    Email = "Email 1"
                };
            }
        }

        public static IList<Token> GeTokens(int count=1, bool neverHtmlEncoded=false)
        {
            var tokens = new List<Token>();
            for (var i = 1; i <= count; i++)
            {
                tokens.Add(new Token("Token" + i, string.Format("<Value{0}>", i), neverHtmlEncoded));
            }

            return tokens;
        }

        public static GiftCard GetGiftCard(bool IsGiftCardActivated, bool addGiftCardUsageHistory = true)
        {
            var giftCard = new GiftCard
            {
                Amount = 100,
                GiftCardType = GiftCardType.Physical,
                GiftCardCouponCode = "Secret",
                RecipientName = "RecipientName 1",
                RecipientEmail = "a@b.c",
                SenderName = "SenderName 1",
                SenderEmail = "d@e.f",
                Message = "Message 1",
                IsRecipientNotified = true,
                CreatedOnUtc = new DateTime(2010, 01, 01),
            };

            if (IsGiftCardActivated)
                giftCard.IsGiftCardActivated = true;

            if (addGiftCardUsageHistory)
            {
                giftCard.GiftCardUsageHistory.Add
                    (
                        new GiftCardUsageHistory
                        {
                            UsedValue = 30,
                            CreatedOnUtc = new DateTime(2010, 01, 01)
                        }
                    );
                giftCard.GiftCardUsageHistory.Add
                    (
                        new GiftCardUsageHistory
                        {
                            UsedValue = 20,
                            CreatedOnUtc = new DateTime(2010, 01, 01)
                        }
                    );
                giftCard.GiftCardUsageHistory.Add
                    (
                        new GiftCardUsageHistory
                        {
                            UsedValue = 5,
                            CreatedOnUtc = new DateTime(2010, 01, 01)
                        }
                    );
            }

            return giftCard;
        }

        public static GiftCardUsageHistory GetGiftCardUsageHistory
        {
            get
            {
                return new GiftCardUsageHistory
                {
                    UsedValue = 1.1M,
                    CreatedOnUtc = new DateTime(2010, 01, 01)
                };
            }
        }

        public static OrderItem GetOrderItem
        {
            get
            {
                return new OrderItem
                {
                    Product = GetProduct,
                    Quantity = 1,
                    UnitPriceInclTax = 1.1M,
                    UnitPriceExclTax = 2.1M,
                    PriceInclTax = 3.1M,
                    PriceExclTax = 4.1M,
                    DiscountAmountInclTax = 5.1M,
                    DiscountAmountExclTax = 6.1M,
                    OriginalProductCost = 7.1M,
                    AttributeDescription = "AttributeDescription1",
                    AttributesXml = "AttributesXml1",
                    DownloadCount = 7,
                    IsDownloadActivated = true,
                    LicenseDownloadId = 8,
                    ItemWeight = 9.87M,
                    RentalStartDateUtc = new DateTime(2010, 01, 01),
                    RentalEndDateUtc = new DateTime(2010, 01, 02)
                };
            }
        }

        public static Shipment GetShipment
        {
            get
            {
                return new Shipment
                {
                    TrackingNumber = "TrackingNumber 1",
                    ShippedDateUtc = new DateTime(2010, 01, 01),
                    DeliveryDateUtc = new DateTime(2010, 01, 02),
                    CreatedOnUtc = new DateTime(2010, 01, 03),
                    TotalWeight = 9.87M,
                    AdminComment = "AdminComment 1"
                };
            }
        }

        public static RecurringPaymentHistory GetRecurringPaymentHistory
        {
            get
            {
                return new RecurringPaymentHistory
                {
                    CreatedOnUtc = new DateTime(2010, 01, 03)
                };
            }
        }

        public static ReturnRequest GetReturnRequest
        {
            get
            {
                return new ReturnRequest
                {
                    CustomNumber = "CustomNumber 1",
                    StoreId = 1,
                    Customer = GetCustomer(),
                    Quantity = 2,
                    ReasonForReturn = "Wrong product",
                    RequestedAction = "Refund",
                    CustomerComments = "Some comment",
                    StaffNotes = "Some notes",
                    ReturnRequestStatus = ReturnRequestStatus.ItemsRefunded,
                    CreatedOnUtc = new DateTime(2010, 01, 01),
                    UpdatedOnUtc = new DateTime(2010, 01, 02),
                };
            }
        }

        public static ReturnRequestReason GetReturnRequestReason
        {
            get
            {
                return new ReturnRequestReason
                {
                    Name = "Name 1",
                    DisplayOrder = 1
                };
            }
        }

        public static ReturnRequestAction GetReturnRequestAction
        {
            get
            {
                return new ReturnRequestAction
                {
                    Name = "Name 1",
                    DisplayOrder = 1
                };
            }
        }

        public static OrderNote GetOrderNote
        {
            get
            {
                return new OrderNote
                {
                    Note = "Note1",
                    DownloadId = 1,
                    DisplayToCustomer = true,
                    CreatedOnUtc = new DateTime(2010, 01, 01)
                };
            }
        }

        public static RecurringPayment GetRecurringPayment(RecurringProductCyclePeriod recurringProductCyclePeriod,
            int cycleLength = 2, bool isActive = true)
        {
            return new RecurringPayment
            {
                CycleLength = cycleLength,
                CyclePeriod = recurringProductCyclePeriod,
                TotalCycles = 3,
                StartDateUtc = new DateTime(2010, 3, 1),
                CreatedOnUtc = new DateTime(2010, 1, 1),
                IsActive = isActive
            };
        }

        public static IList<ShippingOption> GetShippingOptions
        {
            get
            {
                return new List<ShippingOption>
                {
                    new ShippingOption
                    {
                        Name = "a1",
                        Description = "a2",
                        Rate = 3.57M,
                        ShippingRateComputationMethodSystemName = "a4"
                    },
                    new ShippingOption
                    {
                        Name = "b1",
                        Description = "b2",
                        Rate = 7.00M,
                        ShippingRateComputationMethodSystemName = "b4"
                    }
                };
            }
        }

        public static Store GetStore
        {
            get
            {
                return new Store
                {
                    Id = 1,
                    Hosts = "yourstore.com, www.yourstore.com, ",
                    Name = "Store 1",
                    DisplayOrder = 1,
                    Url = "http://www.test.com",
                    DefaultLanguageId = 1,
                    CompanyName = "company name",
                    CompanyAddress = "some address",
                    CompanyPhoneNumber = "123456789",
                    CompanyVat = "some vat",
                };
            }
        }

        public static ScheduleTask GetScheduleTask
        {
            get
            {
                return new ScheduleTask
                {
                    Name = "Task 1",
                    Seconds = 1,
                    Type = "some type 1",
                    Enabled = true,
                    StopOnError = true,
                    LeasedByMachineName = "LeasedByMachineName 1",
                    LeasedUntilUtc = new DateTime(2009, 01, 01),
                    LastStartUtc = new DateTime(2010, 01, 01),
                    LastEndUtc = new DateTime(2010, 01, 02),
                    LastSuccessUtc = new DateTime(2010, 01, 03),
                };
            }
        }

        public static TaxCategory GeTaxCategory
        {
            get
            {
                return new TaxCategory
                {
                    Name = "Books",
                    DisplayOrder = 1
                };
            }
        }

        public static Topic GetTopic
        {
            get
            {
                return new Topic
                {
                    SystemName = "SystemName 1",
                    IncludeInSitemap = true,
                    IncludeInTopMenu = true,
                    IncludeInFooterColumn1 = true,
                    IncludeInFooterColumn2 = true,
                    IncludeInFooterColumn3 = true,
                    DisplayOrder = 1,
                    AccessibleWhenStoreClosed = true,
                    IsPasswordProtected = true,
                    Password = "password",
                    Title = "Title 1",
                    Body = "Body 1",
                    Published = true,
                    TopicTemplateId = 1,
                    MetaKeywords = "Meta keywords",
                    MetaDescription = "Meta description",
                    MetaTitle = "Meta title",
                    SubjectToAcl = true,
                    LimitedToStores = true
                };
            }
        }

        public static TopicTemplate GetTopicTemplate
        {
            get
            {
                return new TopicTemplate
                {
                    Name = "Name 1",
                    ViewPath = "ViewPath 1",
                    DisplayOrder = 1,
                };
            }
        }

        public static VendorNote GetVendorNote
        {
            get
            {
                return new VendorNote
                {
                    Note = "Note1",
                    CreatedOnUtc = new DateTime(2010, 01, 01),
                };
            }
        }

        public static Vendor GetVendor
        {
            get
            {
                return new Vendor
                {
                    Name = "Name 1",
                    Email = "Email 1",
                    Description = "Description 1",
                    AdminComment = "AdminComment 1",
                    PictureId = 1,
                    Active = true,
                    Deleted = true,
                    DisplayOrder = 2,
                    MetaKeywords = "Meta keywords",
                    MetaDescription = "Meta description",
                    MetaTitle = "Meta title",
                    PageSize = 4,
                    AllowCustomersToSelectPageSize = true,
                    PageSizeOptions = "4, 2, 8, 12",
                };
            }
        }

        public static PrivateMessage GetPrivateMessage(Customer fromCustomer, Customer toCustomer, Store store)
        {
            var privateMessage = new PrivateMessage
            {
                Subject = "Private Message 1 Subject",
                Text = "Private Message 1 Text",
                IsDeletedByAuthor = false,
                IsDeletedByRecipient = false,
                IsRead = false,
                CreatedOnUtc = DateTime.UtcNow
            };

            if (fromCustomer != null)
                privateMessage.FromCustomerId = fromCustomer.Id;
            if (toCustomer != null)
                privateMessage.ToCustomerId = toCustomer.Id;
            if (store != null)
                privateMessage.StoreId = store.Id;

            return privateMessage;
        }

        public static ManufacturerTemplate GetManufacturerTemplate
        {
            get
            {
                return new ManufacturerTemplate
                {
                    Name = "Name 1",
                    ViewPath = "ViewPath 1",
                    DisplayOrder = 1,
                };
            }
        }

        public static PredefinedProductAttributeValue GetPredefinedProductAttributeValue
        {
            get
            {
                return new PredefinedProductAttributeValue
                {
                    Name = "Name 1",
                    PriceAdjustment = 1.1M,
                    WeightAdjustment = 2.1M,
                    Cost = 3.1M,
                    IsPreSelected = true,
                    DisplayOrder = 3,
                    ProductAttribute = GetProductAttribute()
                };
            }
        }

        public static ProductAttributeValue GetProductAttributeValue(int id = 1, string name = "Name 1", ProductAttributeMapping productAttributeMapping = null)
        {
            productAttributeMapping = productAttributeMapping ?? GetProductAttributeMapping();
            return new ProductAttributeValue
            {
                Id = id,
                AttributeValueType = AttributeValueType.AssociatedToProduct,
                AssociatedProductId = 10,
                Name = name,
                ColorSquaresRgb = "12FF33",
                ImageSquaresPictureId = 1,
                PriceAdjustment = 1.1M,
                WeightAdjustment = 2.1M,
                Cost = 3.1M,
                Quantity = 2,
                IsPreSelected = true,
                DisplayOrder = 3,
                ProductAttributeMapping = productAttributeMapping,
                ProductAttributeMappingId = productAttributeMapping.Id
            };
        }

        public static ProductCategory GetProductCategory
        {
            get
            {
                return new ProductCategory
                {
                    IsFeaturedProduct = true,
                    DisplayOrder = 1,
                    Product = GetProduct,
                    Category = GetCategory
                };
            }
        }

        public static ProductAttribute GetProductAttribute(int id = 1, string name = "Name 1")
        {
            return new ProductAttribute
            {
                Id = id,
                Name = name,
                Description = "Description 1"
            };
        }

        public static ProductAttributeCombination GetProductAttributeCombination
        {
            get
            {
                return new ProductAttributeCombination
                {
                    AttributesXml = "Some XML",
                    StockQuantity = 2,
                    AllowOutOfStockOrders = true,
                    Sku = "Sku1",
                    ManufacturerPartNumber = "ManufacturerPartNumber1",
                    Gtin = "Gtin1",
                    OverriddenPrice = 0.01M,
                    NotifyAdminForQuantityBelow = 3,
                    Product = GetProduct
                };
            }
        }

        public static ProductAttributeMapping GetProductAttributeMapping(Product product = null, int id = 1, string textPrompt = "TextPrompt 1", AttributeControlType controlType = AttributeControlType.DropdownList, ProductAttribute productAttribute = null)
        {
            product = product ?? GetProduct;
            productAttribute = productAttribute ?? GetProductAttribute();

            return new ProductAttributeMapping
            {
                Id = id,
                TextPrompt = textPrompt,
                IsRequired = true,
                AttributeControlType = controlType,
                DisplayOrder = 1,
                ValidationMinLength = 2,
                ValidationMaxLength = 3,
                ValidationFileAllowedExtensions = "ValidationFileAllowedExtensions 1",
                ValidationFileMaximumSize = 4,
                DefaultValue = "DefaultValue 1",
                ConditionAttributeXml = "ConditionAttributeXml 1",
                Product = product,
                ProductId = product.Id,
                ProductAttribute = productAttribute,
                ProductAttributeId = productAttribute.Id
            };
        }

        public static BlogPost GetBlogPost
        {
            get
            {
                var blogPost = new BlogPost
                {
                    Title = "Title 1",
                    Body = "Body 1",
                    BodyOverview = "BodyOverview 1",
                    AllowComments = true,
                    CommentCount = 1,
                    Tags = "Tags 1",
                    StartDateUtc = new DateTime(2010, 01, 01),
                    EndDateUtc = new DateTime(2010, 01, 02),
                    CreatedOnUtc = new DateTime(2010, 01, 03),
                    MetaTitle = "MetaTitle 1",
                    MetaDescription = "MetaDescription 1",
                    MetaKeywords = "MetaKeywords 1",
                    LimitedToStores = true,
                    Language = GetLanguage
                };

                blogPost.BlogComments.Add
                (
                    new BlogComment
                    {
                        CreatedOnUtc = new DateTime(2010, 01, 03),
                        Customer = GetCustomer()
                    }
                );


                return blogPost;
            }
        }

        public static Language GetLanguage
        {
            get
            {
                return new Language
                {
                    Name = "English",
                    LanguageCulture = "en-Us",
                    UniqueSeoCode = "en",
                    FlagImageFileName = "us.png",
                    Rtl = true,
                    DefaultCurrencyId = 1,
                    Published = true,
                    LimitedToStores = true,
                    DisplayOrder = 1
                };
            }
        }

        public static LocaleStringResource GeLocaleStringResource
        {
            get
            {
                return new LocaleStringResource
                {
                    ResourceName = "ResourceName1",
                    ResourceValue = "ResourceValue2"
                };
            }
        }

        public static LocalizedProperty GetLocalizedProperty
        {
            get
            {
                return new LocalizedProperty
                {
                    EntityId = 1,
                    LocaleKeyGroup = "LocaleKeyGroup 1",
                    LocaleKey = "LocaleKey 1",
                    LocaleValue = "LocaleValue 1"
                };
            }
        }

        public static ActivityLogType GetActivityLogType
        {
            get
            {
                return new ActivityLogType
                {
                    SystemKeyword = "SystemKeyword 1",
                    Name = "Name 1",
                    Enabled = true
                };
            }
        }

        public static ActivityLog GetActivityLog(int id = 1, Customer customer = null, ActivityLogType activityLogType = null)
        {
            customer = customer ?? GetCustomer();
            activityLogType = activityLogType ?? GetActivityLogType;

            return new ActivityLog
            {
                Id = id,
                ActivityLogType = activityLogType,
                CustomerId = customer.Id,
                Customer = customer
            };
        }

        public static BackInStockSubscription GetBackInStockSubscription
        {
            get
            {
                return new BackInStockSubscription
                {
                    Product = GetProduct,
                    Customer = GetCustomer(),
                    CreatedOnUtc = new DateTime(2010, 01, 02)
                };
            }
        }

        public static Log GetLog
        {
            get
            {
                return new Log
                {
                    LogLevel = LogLevel.Error,
                    ShortMessage = "ShortMessage1",
                    FullMessage = "FullMessage1",
                    IpAddress = "127.0.0.1",
                    PageUrl = "http://www.someUrl1.com",
                    ReferrerUrl = "http://www.someUrl2.com",
                    CreatedOnUtc = new DateTime(2010, 01, 01)
                };
            }
        }

        public static Category GetCategory
        {
            get
            {
                return new Category
                {
                    Name = "Books",
                    Description = "Description 1",
                    CategoryTemplateId = 1,
                    MetaKeywords = "Meta keywords",
                    MetaDescription = "Meta description",
                    MetaTitle = "Meta title",
                    ParentCategoryId = 2,
                    PictureId = 3,
                    PageSize = 4,
                    AllowCustomersToSelectPageSize = true,
                    PageSizeOptions = "4, 2, 8, 12",
                    PriceRanges = "1-3;",
                    ShowOnHomePage = false,
                    IncludeInTopMenu = true,
                    Published = true,
                    SubjectToAcl = true,
                    LimitedToStores = true,
                    Deleted = false,
                    DisplayOrder = 5,
                    CreatedOnUtc = new DateTime(2010, 01, 01),
                    UpdatedOnUtc = new DateTime(2010, 01, 02),
                };
            }
        }

        public static CategoryTemplate GetCategoryTemplate
        {
            get
            {
                return new CategoryTemplate
                {
                    Name = "Name 1",
                    ViewPath = "ViewPath 1",
                    DisplayOrder = 1,
                };
            }
        }

        public static Manufacturer GetManufacturer
        {
            get
            {
                return new Manufacturer
                {
                    Name = "Name",
                    Description = "Description 1",
                    ManufacturerTemplateId = 1,
                    MetaKeywords = "Meta keywords",
                    MetaDescription = "Meta description",
                    MetaTitle = "Meta title",
                    PictureId = 3,
                    PageSize = 4,
                    AllowCustomersToSelectPageSize = true,
                    PageSizeOptions = "4, 2, 8, 12",
                    PriceRanges = "1-3;",
                    Published = true,
                    SubjectToAcl = true,
                    LimitedToStores = true,
                    Deleted = false,
                    DisplayOrder = 5,
                    CreatedOnUtc = new DateTime(2010, 01, 01),
                    UpdatedOnUtc = new DateTime(2010, 01, 02),
                };
            }
        }
    }

   
}
