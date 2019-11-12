using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BraintreeHttp;
using PayPal.Core;
using PayPal.v1.PaymentExperience;
using PayPal.v1.Payments;

namespace eTeatar.Web.Paypal
{
    public static class PayPalHelper
    {
        private static PayPalHttpClient _client;

        public static async Task<string> GeneratePayment(string name, float price, int quantity, string sucessUrl,
            string cancelUrl)
        {
            SandboxEnvironment environment = new SandboxEnvironment(
                "AcsZudPzaw7QNmu68Q15SdtKMCM0HJMKO-q-Lp1IXgLwqe-Dt9CWOYqsBtZ_QiS2hVVL0o50BK8xW0Dk",
                "EJo0Vn_JKFf5qq4pN6zOKm50fmYN4dI8ZTeB5j2vl5YtWRnKeAPOvXK2WZ4faxGA8QaUM1KhVj-kF8kr");
            _client = new PayPalHttpClient(environment);

            string guid = Guid.NewGuid().ToString();

            Payment payment = new Payment
            {
                Intent = "Sale",
                ExperienceProfileId = "XP-T4NZ-V32N-WVTM-SWHB",
                Payer = new Payer
                {
                    PaymentMethod = "paypal"
                },
                Transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        InvoiceNumber = guid,
                        Amount = new Amount
                        {
                            Currency = "EUR",
                            Total = (quantity * price).ToString("0.00")
                        },
                        ItemList = new ItemList
                        {
                            Items = new List<Item>
                            {
                                new Item
                                {
                                    Name = name,
                                    Currency = "EUR",
                                    Price = price.ToString("0.00"),
                                    Quantity = quantity.ToString()
                                }
                            }
                        }
                    }
                },
                RedirectUrls = new RedirectUrls
                {
                    ReturnUrl = sucessUrl,
                    CancelUrl = cancelUrl
                }
            };

            PaymentCreateRequest request = new PaymentCreateRequest();
            request.RequestBody(payment);

            try
            {
                HttpResponse response = await _client.Execute(request);
                Payment result = response.Result<Payment>();

                string redirectUrl = null;

                foreach (LinkDescriptionObject link in result.Links)
                    if (link.Rel.Equals("approval_url"))
                        redirectUrl = link.Href;

                return redirectUrl ?? "Doslo je greske!";
            }
            catch (HttpException)
            {
                return "Doslo je do greske!";
            }
        }

        public static async Task<bool> ExecutePayment(string paymentId, string payerId)
        {
            SandboxEnvironment environment = new SandboxEnvironment(
                "AcsZudPzaw7QNmu68Q15SdtKMCM0HJMKO-q-Lp1IXgLwqe-Dt9CWOYqsBtZ_QiS2hVVL0o50BK8xW0Dk",
                "EJo0Vn_JKFf5qq4pN6zOKm50fmYN4dI8ZTeB5j2vl5YtWRnKeAPOvXK2WZ4faxGA8QaUM1KhVj-kF8kr");
            _client = new PayPalHttpClient(environment);


            PaymentExecuteRequest request = new PaymentExecuteRequest(paymentId);

            request.RequestBody(new PaymentExecution
            {
                PayerId = payerId
            });


            try
            {
                HttpResponse response = await _client.Execute(request);

                HttpStatusCode Status = response.StatusCode;

                return Status.ToString() == "OK";
            }
            catch (HttpException)
            {
                return false;
            }
        }

        public static async Task<string> CreateProfile()
        {
            SandboxEnvironment environment = new SandboxEnvironment(
                "AcsZudPzaw7QNmu68Q15SdtKMCM0HJMKO-q-Lp1IXgLwqe-Dt9CWOYqsBtZ_QiS2hVVL0o50BK8xW0Dk",
                "EJo0Vn_JKFf5qq4pN6zOKm50fmYN4dI8ZTeB5j2vl5YtWRnKeAPOvXK2WZ4faxGA8QaUM1KhVj-kF8kr");
            _client = new PayPalHttpClient(environment);


            WebProfileCreateRequest request = new WebProfileCreateRequest();
            WebProfile profile = new WebProfile
            {
                Name = "WebProfil",
                Presentation = new Presentation
                {
                    BrandName = "eTeatar",
                    LocaleCode = "US",
                    LogoImage = "https://www.paypal.com/"
                },
                InputFields = new InputFields
                {
                    AddressOverride = 0,
                    AllowNote = false,
                    NoShipping = 1
                },
                FlowConfig = new FlowConfig
                {
                    BankTxnPendingUrl = "https://www.paypal.com/",
                    LandingPageType = "billing",
                    UserAction = "commit",
                    ReturnUriHttpMethod = "POST"
                },
                Temporary = true
            };

            request.RequestBody(profile);


            HttpResponse response = await _client.Execute(request);
            WebProfile result = response.Result<WebProfile>();
            
            return result.Id;
        }
    }
}