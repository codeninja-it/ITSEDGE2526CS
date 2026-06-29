using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ManagedNativeWifi;

namespace Maui03
{
    public class WifiScanner
    {
        public class Rete
        {
            public string Ssid { get; set; }
            public string MacAddress { get; set; }
            public int Rssi { get; set; }
            public int SignalQuality { get; set; }
            public double FrequencyKhz { get; set; }
            public string Channel { get; set; }
        }

        public async Task<List<Rete>> GetAllNearbyNetworksAsync()
        {
            var trovate = new List<Rete>();

            using (var cts = new CancellationTokenSource())
            {
                try
                {
                    var timeout = TimeSpan.FromSeconds(4);

                    IEnumerable<Guid> scannedInterfaces = await NativeWifi.ScanNetworksAsync(timeout, cts.Token);

                    if (scannedInterfaces == null || !scannedInterfaces.Any())
                    {
                        System.Diagnostics.Debug.WriteLine("Nessuna interfaccia Wi-Fi ha eseguito la scansione.");
                    }

                    var bssNetworks = NativeWifi.EnumerateBssNetworks();

                    foreach (var bss in bssNetworks)
                    {
                        string ssidStr = bss.Ssid.ToString();

                        trovate.Add(new Rete
                        {
                            Ssid = string.IsNullOrWhiteSpace(ssidStr) ? "[Rete Nascosta]" : ssidStr,
                            MacAddress = bss.Bssid.ToString(),
                            Rssi = bss.Rssi,
                            SignalQuality = bss.LinkQuality,
                            FrequencyKhz = bss.Frequency,
                            Channel = bss.Channel.ToString()
                        });
                    }
                }
                catch (OperationCanceledException)
                {
                    System.Diagnostics.Debug.WriteLine("La scansione Wi-Fi è stata interrotta.");
                    crossReadCache(trovate);
                }
                catch (UnauthorizedAccessException)
                {
                    throw new Exception("Errore permessi: Verifica che la 'Localizzazione/Posizione' sia ATTIVA nelle impostazioni di Windows Privacy.");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Errore durante la scansione Wi-Fi: {ex.Message}");
                }
            }

            return trovate.OrderByDescending(n => n.Rssi).ToList();
        }

        private void crossReadCache(List<Rete> list)
        {
            var bssNetworks = NativeWifi.EnumerateBssNetworks();
            foreach (var bss in bssNetworks)
            {
                string ssidStr = bss.Ssid.ToString();
                list.Add(new Rete
                {
                    Ssid = string.IsNullOrWhiteSpace(ssidStr) ? "[Rete Nascosta]" : ssidStr,
                    MacAddress = bss.Bssid.ToString(),
                    Rssi = bss.Rssi,
                    SignalQuality = bss.LinkQuality,
                    FrequencyKhz = bss.Frequency,
                    Channel = bss.Channel.ToString()
                });
            }
        }
    }


}
