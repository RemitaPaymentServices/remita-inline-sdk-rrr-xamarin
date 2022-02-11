using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace remita_inline_sdk_rrr_xamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            string rrr = editor.Text.Trim(); 
            //string rrr = "160008273205";
            string url = "https://remitademo.net";
            string key = "QzAwMDAzNTQ0MDh8Nzg2Mzc0MTY1MnxhNjBlOTRjNTk0MjU3OTJlYjA1YjQzNGY0YzAyMTA1YWFhNzRiZGM2MzViZTIwMzY2ZTAxMzQyZDNhYWZiNGUxMDVjNTRkMDNmMjBkZjY4ZGYzYzdmMmY4ODU5YzNiOTk2OGI3MmFiODQ3NTUyNTYyNmVhYTQ2NDFjYmUwNTE5NA==";
           
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<!DOCTYPE html>" +
                "<html lang=\"en\">"
                + "<header><meta name=\"viewport\" content=\"initial-scale=1.0\"/>" +
                "</header>" +
                "<body  onload=\"makePayment()\">" +
                "    <script>" +
                "       function makePayment() {" +
                "       var paymentEngine = RmPaymentEngine.init({" +
                "key:'" + key + "'," +
                "                \"processRrr\": \"" + true + "\"," +
                "extendedData:" + "{ " +
                "customFields: [ " +
                "{ " +
                "name: \"rrr\"," +
                "value:'" + rrr + "'" +
                "} " +
                " ]" +
                "}" + "," +
                "                    onSuccess: function (response) { " +
                "                        console.log(JSON.stringify(response)); " +
                "                    }, " +
                "                    onError: function (response) { " +
                "                        console.log(JSON.stringify(response)); " +
                "                    }, " +
                "                    onClose: function () { " +
                "                        console.log(\"onClose\"); " +
                "                    },                  " +
                "                }); " +
                "                paymentEngine.openIframe(); " +
                "        } " +
                "    </script> " +
                "    " + "<script type=\"text/javascript\" src=\"" + url + "/payment/v1/remita-pay-inline.bundle.js\"></script> " +

                "</body> " +
                " " +
                "</html>";
            var browser = new WebView();
            browser.Source = htmlSource;
            Content = browser;
        }
    }
}
