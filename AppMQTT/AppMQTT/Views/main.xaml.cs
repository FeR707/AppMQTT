using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenNETCF.MQTT;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace AppMQTT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class main : ContentPage
    {
        MQTTClient mqtt;
        List<string> mensajes;
        int m;
        public main()
        {
            InitializeComponent();
            mensajes = new List<string>();
            mqtt = new MQTTClient("iothall.sytes.net", 1883);
            mqtt.Connect("andres", "test", "test");
            mqtt.MessageReceived += Mqtt_MessageReceived;
            //mqtt.Connect("AppMovil");
            lstRecibidos.ItemsSource = mensajes;
            mqtt.Subscriptions.Add(new Subscription("conexion/App"));

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (mensajes.Count > m)
                {
                    lstRecibidos.ItemsSource = null;
                    lstRecibidos.ItemsSource = mensajes;
                    string[] datos = mensajes[mensajes.Count - 1].Split('=');
                    if (datos.Length == 2)
                    {
                        switch (datos[0])
                        {
                            case "L":
                                lblLed.Text = datos[1] == "1" ? "Endendido" : "Apagado";
                                break;
                            case "R":
                                lblRele.Text = datos[1] == "1" ? "Endendido" : "Apagado";
                                break;
                            case "F":
                                lblLDR.Text = datos[1];
                                break;
                            default:
                                break;
                        }
                    }
                    m = mensajes.Count;
                }

                return true;
            });
        }

        private void Mqtt_MessageReceived(string topic, QoS qos, byte[] payload)
        {
            string mensaje = System.Text.Encoding.UTF8.GetString(payload);
            mensajes.Add(mensaje);
        }

        private void btnEncenderLed_Clicked(object sender, EventArgs e)
        {
            if (mqtt.IsConnected)
            {
                mqtt.Publish("IoTFacil/Dispositivo", "L1", QoS.FireAndForget, false);
            }
        }

        private void btnApagarLed_Clicked(object sender, EventArgs e)
        {
            if (mqtt.IsConnected)
            {
                mqtt.Publish("IoTFacil/Dispositivo", "L0", QoS.FireAndForget, false);
            }
        }

        private void btnEncenderRelevador_Clicked(object sender, EventArgs e)
        {
            if (mqtt.IsConnected)
            {
                mqtt.Publish("IoTFacil/Dispositivo", "R1", QoS.FireAndForget, false);
            }
        }

        private void btnApagarRelevador_Clicked(object sender, EventArgs e)
        {
            if (mqtt.IsConnected)
            {
                mqtt.Publish("IoTFacil/Dispositivo", "R0", QoS.FireAndForget, false);
            }
        }

        private void btnActualizarLDR_Clicked(object sender, EventArgs e)
        {
            if (mqtt.IsConnected)
            {
                mqtt.Publish("IoTFacil/Dispositivo", "F?", QoS.FireAndForget, false);
            }
        }
    }
}