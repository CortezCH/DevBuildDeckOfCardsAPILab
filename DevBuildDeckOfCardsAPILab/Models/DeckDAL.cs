using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DevBuildDeckOfCardsAPILab.Models
{
    public class DeckDAL
    {
        public Deck GetDeck()
        {
            //First step is to put in your Endpoint, your URL 
            string url = "https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";

            //Next we need to create our request 
            HttpWebRequest request = WebRequest.CreateHttp(url);

            //Next if your API needs any kind of login or key, that may go here 
            //SWAPI doesn't need anything so we're good

            //Now we're ready to send off our request and grab the server's response 
            //Inside our response, the resulting data lives 
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Pull the result into a stream reader which will then give us a string 
            StreamReader rd = new StreamReader(response.GetResponseStream());

            //Grab our response string - read to end starts at the top of our response file and returns each line 
            //until it hits the end. 
            string result = rd.ReadToEnd();
            rd.Close();

            //This line converts our JSON string into a person object automatically 
            Deck d = JsonConvert.DeserializeObject<Deck>(result);

            //Later we'll convert our string into a model which makes it much easier to use for .net
            return d;
        }

        public Deck DrawCards(string deckID, int count)
        {
            //First step is to put in your Endpoint, your URL 
            string url = $"https://deckofcardsapi.com/api/deck/{deckID}/draw/?count={count}";

            //Next we need to create our request 
            HttpWebRequest request = WebRequest.CreateHttp(url);

            //Next if your API needs any kind of login or key, that may go here 
            //SWAPI doesn't need anything so we're good

            //Now we're ready to send off our request and grab the server's response 
            //Inside our response, the resulting data lives 
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Pull the result into a stream reader which will then give us a string 
            StreamReader rd = new StreamReader(response.GetResponseStream());

            //Grab our response string - read to end starts at the top of our response file and returns each line 
            //until it hits the end. 
            string result = rd.ReadToEnd();
            rd.Close();

            //This line converts our JSON string into a person object automatically 
            Deck d = JsonConvert.DeserializeObject<Deck>(result);

            //Later we'll convert our string into a model which makes it much easier to use for .net
            return d;
        }

        public Deck Reshuffle(string deckID)
        {
            //First step is to put in your Endpoint, your URL 
            string url = $"https://deckofcardsapi.com/api/deck/{deckID}/shuffle/";

            //Next we need to create our request 
            HttpWebRequest request = WebRequest.CreateHttp(url);

            //Next if your API needs any kind of login or key, that may go here 
            //SWAPI doesn't need anything so we're good

            //Now we're ready to send off our request and grab the server's response 
            //Inside our response, the resulting data lives 
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Pull the result into a stream reader which will then give us a string 
            StreamReader rd = new StreamReader(response.GetResponseStream());

            //Grab our response string - read to end starts at the top of our response file and returns each line 
            //until it hits the end. 
            string result = rd.ReadToEnd();
            rd.Close();

            //This line converts our JSON string into a person object automatically 
            Deck d = JsonConvert.DeserializeObject<Deck>(result);

            //Later we'll convert our string into a model which makes it much easier to use for .net
            return d;
        }
    }
}
