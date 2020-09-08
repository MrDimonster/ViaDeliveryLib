using System.Collections.Generic;

namespace ViaDeliveryLib
{
    public static class TestObjects
    {
        public static InSalesPointListRequestBody InSalesPointListRequestBody = 
            new InSalesPointListRequestBody
            {
                Order = new Body
                {
                    AccountId = 618560,
                    OrderLines = new List<OrderLine>
                    {
                          new OrderLine
                          {
                               ProductId = 162637855,
                               VariantId = 279627589,
                               Quantity = 1,
                               Weight = "0.012",
                               Dimensions = "10x20x20"
                          }
                    },
                    CurrencyIsoCode = "RUB",
                    ItemsPrice = 750,
                    TotalWeight = "0.01",
                    ShippingAddress = new ShippingAddress
                    {
                        FullLocalityName = "г Москва",
                        Location = new Location
                        {
                            KladrCode = "7700000000000",
                            Zip = "127349",
                            RegionZip = "101000",
                            Country = "RU",
                            State = "Москва",
                            StateType = "г",
                            Area = null,
                            AreaType = null,
                            City = "Москва",
                            CityType = "г",
                            Settlement = null,
                            SettlementType = null,
                            Bounds = new Bounds
                            {
                                BottomLeft = new BottomLeft
                                {
                                    Latitude = 55.30081316694387m,
                                    Longitude = 36.97434012987538m
                                },
                                TopRight = new TopRight
                                {
                                    Latitude = 56.200620833056135m,
                                    Longitude = 38.26097987012462m
                                }
                            }
                        }
                    }
                }
            };

        public static Delivery Delivery = new Delivery
        {
            Point = "cbf3855d-b1f2-4d80-a56a-e01eef654bcd",
            Id = "12345-SHIP",
            Service = "DELIVERY",
            Package = new Package
            {
                Height = 200,
                Length = 100,
                Weight = 90000,
                Width = 100
            },
            Payment = new Payment
            {
                Cost = 200,
                Currency = "RUB",
                deliveryCost = 99,
                PaymentType = "PREPAYMENT",
                Vat = 20
            },
            Goods = new List<OrderItem>
            {
                new OrderItem
                {
                    Barcode = null,
                    Code = "01001",
                    CodeGTD = null,
                    CodeTNVED = null,
                    Country = null,
                    Name = "Колбаса",
                    Price = 100,
                    Value = 2,
                    Vat = 20
                }
            },
            Customer = new Customer
            {
                Email = "test@mail.ru",
                Name = "Петров Петр Александрович",
                Phone = "+79293447625"
            },
            ShipDate = "2021-01-01",
            Undeliverable = "RETURN"
        };

        public static InsalesOrderRequestBody GetInsalesOrderRequestBodyForTest()
        {
            string json = @"{
    'order_lines': [
    {
        'id': 220309651,
        'order_id': 30335549,
        'sale_price': 5900,
        'full_sale_price': 5900,
        'total_price': 5900,
        'full_total_price': 5900,
        'discounts_amount': 0,
        'quantity': 1,
        'reserved_quantity': 0,
        'weight': null,
        'dimensions': null,
        'variant_id': 242084063,
        'product_id': 138512437,
        'sku': null,
        'barcode': null,
        'title': 'ДНК-тестирование для подбора питания (7)',
        'unit': 'pce',
        'comment': null,
        'updated_at': '2020-04-05T14:25:14.000+03:00',
        'created_at': '2020-04-05T14:25:14.000+03:00',
        'bundle_id': null,
        'vat': 20,
        'fiscal_product_type': 1
    }],
    'discount': null,
    'shipping_address':
    {
        'id': 34326954,
        'fields_values': [],
        'name': 'Test User',
        'surname': null,
        'middlename': null,
        'phone': '+79031231212',
        'full_name': 'Test User',
        'full_locality_name': 'г Москва',
        'full_delivery_address': 'г Москва',
        'address_for_gis': 'г Москва',
        'location_valid': true,
        'address': null,
        'country': null,
        'state': 'г Москва',
        'city': 'Москва',
        'zip': null,
        'street': null,
        'house': null,
        'flat': null,
        'location':
        {
            'kladr_code': '7700000000000',
            'zip': null,
            'region_zip': '101000',
            'country': 'RU',
            'state': 'Москва',
            'state_type': 'г',
            'area': null,
            'area_type': null,
            'city': 'Москва',
            'city_type': 'г',
            'settlement': null,
            'settlement_type': null,
            'address': '',
            'street': null,
            'street_type': null,
            'house': null,
            'flat': null,
            'is_kladr': true,
            'latitude': '55.750717',
            'longitude': '37.61766',
            'autodetected': null
        }
    },
    'client':
    {
        'id': 32058673,
        'email': 'user_name@gmail.com',
        'name': 'Test User',
        'phone': '+79031231212',
        'created_at': '2020-04-05T14:25:14.000+03:00',
        'updated_at': '2020-04-05T14:25:14.000+03:00',
        'registered': false,
        'subscribe': true,
        'client_group_id': null,
        'surname': null,
        'middlename': null,
        'bonus_points': 0,
        'ip_addr':
        {
            'family': 2,
            'addr': 1334434291,
            'mask_addr': 4294967295
        },
        'type': 'Client::Individual',
        'correspondent_account': null,
        'settlement_account': null,
        'consent_to_personal_data': null,
        'progressive_discount': null,
        'group_discount': null,
        'fields_values': []
    },
    'discounts': [],
    'total_price': 6050,
    'items_price': 5900,
    'id': 30335549,
    'key': '302515869680049f8f1f0b3dc3f4f182',
    'number': 20101,
    'comment': '',
    'archived': false,
    'delivery_title': 'Доставка в точки самовывоза',
    'delivery_description': 'Доставка в точки самовывоза',
    'delivery_price': 150,
    'full_delivery_price': 150,
    'payment_description': '<p>При получении заказа</p>',
    'payment_title': 'Предоплата',
    'first_referer': null,
    'first_current_location': '/',
    'first_query': null,
    'first_source_domain': null,
    'first_source': 'Прямой трафик',
    'referer': null,
    'current_location': '/',
    'query': null,
    'source_domain': null,
    'source': 'Прямой трафик',
    'fulfillment_status': 'new',
    'custom_status':
    {
        'permalink': 'novyy',
        'title': 'Новый'
    },
    'delivered_at': null,
    'accepted_at': null,
    'created_at': '2020-04-05T14:25:14.000+03:00',
    'updated_at': '2020-04-05T14:25:14.000+03:00',
    'financial_status': 'pending',
    'delivery_date': null,
    'delivery_from_hour': null,
    'delivery_to_hour': null,
    'paid_at': null,
    'delivery_variant_id': 2326978,
    'payment_gateway_id': 656499,
    'margin': '0.0',
    'client_transaction_id': null,
    'currency_code': 'RUR',
    'cookies':
    {
        'roistat_visit': '73666',
        'roistat_visit_cookie_expire': '1209600'
    },
    'account_id': 503186,
    'manager_comment': null,
    'locale': 'ru',
    'delivery_info':
    {
        'delivery_variant_id': 2326978,
        'tariff_id': null,
        'title': null,
        'description': null,
        'price': 150,
        'shipping_company': null,
        'shipping_company_handle': 'Via delivery',
        'delivery_interval':
        {
            'min_days': 3,
            'max_days': 5,
            'description': 'от 3-х до 4 дней'
        },
        'errors': [],
        'warnings': [],
        'outlet':
        {
            'id': '4856bdbcbaf3815e889440af77092f73',
            'external_id': 6644,
            'latitude': 55.614061333,
            'longitude': 37.261990679,
            'title': 'Y741 - Пятерочка',
            'description': 'ПВЗ в Пятерочке',
            'address': 'г.Москва, Базовая ул, 2 стр.1',
            'payment_method': [],
            'source_id': 21026
        }
    },
    'responsible_user_id': null,
    'total_profit': '1290.0'
}
";
            return new JsonSerializer().DeserializeObject<InsalesOrderRequestBody>(json);
        }

    }
}
