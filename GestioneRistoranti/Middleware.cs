using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using GestioneRistoranti.Dati;

namespace GestioneRistoranti
{
    public class Middleware
    {
        private string endpoint;
        private string[] tabelle = new string[] {"tavoli", "piatti", "ordini", "comande"};
        public Middleware(string url)
        {
            endpoint = url;
        }

        public async void AddTavolo(Tavolo nuovo)
        {
            HttpClient esecutore = new HttpClient();
            StringContent pacchetto = new StringContent(
                JsonSerializer.Serialize(nuovo),
                UnicodeEncoding.UTF8,
                "application/json"
            );
            await esecutore.PostAsync(endpoint, pacchetto);
        }

        public async void DeleteTavolo(Tavolo daCancellare)
        {
            HttpClient browser = new HttpClient();
            HttpResponseMessage risposta = await browser.GetAsync(
                $"{endpoint}?act=del&tab=tavoli&key=idtavolo&id={daCancellare.idtavolo}"
            );
        }

        public async Task<List<Tavolo>> GetTavoli()
        {
            HttpClient browser = new HttpClient();
            HttpResponseMessage risposta = await browser.GetAsync($"{endpoint}?tab=tavoli");
            if (risposta.IsSuccessStatusCode)
            {
                string buffer = await risposta.Content.ReadAsStringAsync();
                List<Tavolo>? dataset = JsonSerializer.Deserialize<List<Tavolo>>(buffer);
                if(dataset != null)
                    return dataset;
            }
            return new List<Tavolo>();
        }
    }
}
