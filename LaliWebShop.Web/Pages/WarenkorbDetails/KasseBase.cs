using Blazored.LocalStorage;
using Lali.Common;
using LaliWebShop.Models.Dtos;
using LaliWebShop.Web.Helper;
using LaliWebShop.Web.Services.Kontrakte;
using LaliWebShop.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LaliWebShop.Web.Pages
{
    public class KasseBase:ComponentBase
    {
      
        public IEnumerable<ArtikelDto> Artikels { get; set; }

        [Inject]
        public IArtikelService _artikelService { get; set; }

        [Inject]
        public IBestellungService _bestellungService { get; set; }

        [Inject]
        public IBezahlungMethodeService _bezahlungMethodeService { get; set; }

        [Inject]
        public IJSRuntime js { get; set; }

        [Parameter]
        public bool InBearbeitung { get; set; } = false;
        public BestellungPosDto Bestellung { get; set; } = null;

        public IEnumerable<BestellungPosDto> Bestellungs { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            InBearbeitung = true;
            List<WarenkorbSicht> Warenkorb = await _localStorage.GetItemAsync<List<WarenkorbSicht>>(SD.Warenkorb);
            Artikels = await _artikelService.GetItems();
            Bestellung = new()
            {
                Bestellung = new()
                {
                   SummeNetto = 0,

                    Status = SD.Status_Bevorstehend,

                },

                BestellungItems = new List<BestellungItemDto>()
              
            };
            foreach(var item in Warenkorb)
            {
                ArtikelDto artikel = Artikels.FirstOrDefault(a => a.Id == item.ArtikelId);
             

                BestellungItemDto bestellungItemDto = new()
                {
                    ArtikelId = item.ArtikelId,
                    Menge = item.Count,
                    ArtikelPreisSingleNetto = artikel.PreisSingleNetto,
                    ArtikelName = artikel.Name,
                    Artikel = artikel
                };

                Bestellung.BestellungItems.Add(bestellungItemDto);
                Bestellung.Bestellung.SummeNetto += (item.Count * artikel.PreisSingleNetto);
            }

            if (await _localStorage.GetItemAsync<BenutzerDto>(SD.Local_BenutzerDetails) != null)
            {
                var benutzerInfo = await _localStorage.GetItemAsync<BenutzerDto>(SD.Local_BenutzerDetails);
                Bestellung.Bestellung.BenutzerId = benutzerInfo.Id;
                Bestellung.Bestellung.Name = benutzerInfo.Name;
                Bestellung.Bestellung.Vorname = benutzerInfo.vorname;
                Bestellung.Bestellung.Email = benutzerInfo.Email;
                Bestellung.Bestellung.HandyNummer = benutzerInfo.HandyNummer;
                ////////
                //Bestellung.Bestellung.Anrede = benutzerInfo.Anrede;
                //Bestellung.Bestellung.Strasse = benutzerInfo.Strasse;
                //Bestellung.Bestellung.Hausnummer = benutzerInfo.Hausnummer;
                //Bestellung.Bestellung.Plz = benutzerInfo.Plz;
                //Bestellung.Bestellung.Ort = benutzerInfo.Ort;
                //Bestellung.Bestellung.Land = benutzerInfo.Land;

            }

            InBearbeitung = false;
        }

        public async Task BehandleKasse()
        {
            try
            {
                InBearbeitung = true;
                var bezahlungDto = new BezahlungDto()
                {
                    Bestellung=Bestellung
                };

                var result = await _bezahlungMethodeService.Checkout(bezahlungDto);

                //var StripeSessionAndPI = result.Data.ToString().Split(';');

                Bestellung.Bestellung.SessionId = result.Data.ToString();
                //Bestellung.Bestellung.BezahlungId = StripeSessionAndPI[1];

                var bestellungDTOSaved = await _bestellungService.Add(bezahlungDto);

                await _localStorage.SetItemAsync(SD.Local_BestellungsDetails, bestellungDTOSaved);

                await js.InvokeVoidAsync("redirectToCheckout",result.Data.ToString());
            }
            catch (Exception e)
            {
                await js.ToastrError(e.Message);
            }
        }



        //protected IEnumerable<WarenkorbItemDto> warenkorbItemDtos { get; set; }
        //protected int GesamteMenge { get; set; }
        //protected string BezahlungsBezeichnung { get; set; }
        //protected decimal BezahlungsHoehe { get; set; }

        //[Inject]
        //public IWarenkorbService warenkorbService { get; set; }

        //protected override async Task OnInitializedAsync()
        //{
        //    try
        //    {
        //        //warenkorbItemDtos = await warenkorbService.GetItems(FestProgrammiert.KundeId);
        //        if(warenkorbItemDtos != null)
        //        {
        //            Guid bestellungGuid = Guid.NewGuid();
        //            BezahlungsHoehe = warenkorbItemDtos.Sum(p => p.Gesamtpreis);
        //            GesamteMenge = warenkorbItemDtos.Sum(a => a.ArtikelMenge);
        //            BezahlungsBezeichnung = $"B_{FestProgrammiert.KundeId}_{bestellungGuid}";

        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    try
        //    {
        //        if (firstRender)
        //        {
        //            await js.InvokeVoidAsync("initPayPalButton");
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        //public bool IsProcessing { get; set; } = false;
        //private OrderDTO Order { get; set; } = null;
        //private IEnumerable<ProductDTO> Products { get; set; }

        //protected override async Task OnInitializedAsync()
        //{
        //    IsProcessing = true;
        //    List<ShoppingCart> cart = await _localStorage.GetItemAsync<List<ShoppingCart>>(SD.ShoppingCart);
        //    Products = await _productService.GetAll();
        //    Order = new()
        //    {
        //        OrderHeader = new()
        //        {
        //            OrderTotal = 0,
        //            Status = SD.Status_Pending
        //        },
        //        OrderDetails = new List<OrderDetailDTO>()
        //    };

        //    foreach (var item in cart)
        //    {
        //        ProductDTO product = Products.FirstOrDefault(u => u.Id == item.ProductId);
        //        ProductPriceDTO productPrice = product.ProductPrices.FirstOrDefault(u => u.Id == item.ProductPriceId);

        //        OrderDetailDTO orderDetailDTO = new()
        //        {
        //            ProductId = item.ProductId,
        //            Size = productPrice.Size,
        //            Count = item.Count,
        //            Price = productPrice.Price,
        //            ProductName = product.Name,
        //            Product = product
        //        };
        //        Order.OrderDetails.Add(orderDetailDTO);
        //        Order.OrderHeader.OrderTotal += (item.Count * productPrice.Price);
        //    }

        //    if (await _localStorage.GetItemAsync<UserDTO>(SD.Local_UserDetails) != null)
        //    {
        //        var userInfo = await _localStorage.GetItemAsync<UserDTO>(SD.Local_UserDetails);
        //        Order.OrderHeader.UserId = userInfo.Id;
        //        Order.OrderHeader.Name = userInfo.Name;
        //        Order.OrderHeader.Email = userInfo.Email;
        //        Order.OrderHeader.PhoneNumber = userInfo.PhoneNumber;

        //    }

        //    IsProcessing = false;
        //}


        //private async Task HandleCheckout()
        //{
        //    try
        //    {
        //        IsProcessing = true;
        //        var paymentDto = new StripePaymentDTO()
        //        {
        //            Order = Order
        //        };

        //        var result = await _paymentService.Checkout(paymentDto);

        //        var StripeSessionAndPI = result.Data.ToString().Split(';');

        //        Order.OrderHeader.SessionId = StripeSessionAndPI[0];
        //        Order.OrderHeader.PaymentIntentId = StripeSessionAndPI[1];

        //        var orderDTOSaved = await _orderService.Create(paymentDto);

        //        await _localStorage.SetItemAsync(SD.Local_OrderDetails, orderDTOSaved);

        //        await js.InvokeVoidAsync("redirectToCheckout", StripeSessionAndPI[0]);
        //    }
        //    catch (Exception e)
        //    {
        //        await js.ToastrError(e.Message);
        //    }
        //}


    }

}

