using Blackjack.Models;
using System.Collections.Generic;
using System.Web.Mvc;


namespace Blackjack.Controllers
{

    public class BlackjackController : Controller
    {
        static Deck freshDeck = new Deck();
        
        static List<Card> playerCard = new List<Card>();
        static List<Card> dealerCard = new List<Card>();

        static int playerValue = 0;
        static int dealerValue = 0;
        static int deckIndex = 0;
        static int totalAmount;
        static int Betamount;

        [HttpGet]
        public ActionResult Bet()
        {
            return View();
        }


        /// <summary>
        /// Takes input for Bet Amount from the user
        /// </summary>
        /// <param name="Total"></param>
        /// <param name="betAmount"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Bet(int Total, int betAmount)
        {
            totalAmount = Total;
            Betamount = betAmount;
            
            return RedirectToAction("Game");
        }


        int leftAmount = totalAmount - Betamount;

        [HttpGet]
        public ActionResult Game(int id=0)
        {
            
            ViewBag.Total = leftAmount;
            ViewBag.Amount = Betamount;
            return View();
        }

      
        /// <summary>
        /// Game method which distribute two card to the player and dealer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Game()
        {
            

            ViewBag.Total = leftAmount;
            ViewBag.Amount = Betamount;

            for (int i = 0; i < 2; i++)
            {
                playerCard.Add(freshDeck.Cards[deckIndex]);
                playerValue = playerValue + freshDeck.Cards[deckIndex].Value;
                deckIndex++;
            }

            ViewBag.displayPCard0 = playerCard[0];
            ViewBag.displayPCard1 = playerCard[1];

            ViewBag.playervalue = playerValue;
            
            for (int j = 0; j < 2; j++)
            {
                dealerCard.Add(freshDeck.Cards[deckIndex]);
                dealerValue = dealerValue + freshDeck.Cards[deckIndex].Value;
                deckIndex++;
            }
            ViewBag.displayDCard0 = dealerCard[0];
            ViewBag.displayDCard1 = dealerCard[1];

            ViewBag.dealervalue = dealerValue;
            
            if (playerValue == 21)
            {
                leftAmount = leftAmount + 2*Betamount;
                ViewBag.winner = "BlackJack-- Player won the game !!!!";
                ViewBag.won = "You won : " + Betamount;
                ViewBag.Totalamount = "Total Profit : " + leftAmount;
            }

            return View();
        }

        
        /// <summary>
        /// Hit button, distribute single card to the player
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Hit()
        {
            ViewBag.Total = leftAmount;
            ViewBag.Amount = Betamount;

            playerCard.Add(freshDeck.Cards[deckIndex]);
            playerValue = playerValue + freshDeck.Cards[deckIndex].Value;
            deckIndex++;

            ViewBag.playervalue = playerValue;
            ViewBag.dealervalue = dealerValue;

            ViewBag.displayPCard0 = playerCard[0];
            ViewBag.displayPCard1 = playerCard[1];
            ViewBag.displayPCard2 = playerCard[2];

            ViewBag.displayDCard0 = dealerCard[0];
            ViewBag.displayDCard1 = dealerCard[1];



            if (playerValue == 21)
            {
                leftAmount = leftAmount + 2*Betamount;
                ViewBag.winner = "Player Won -- Dealer Busted !!!";
                ViewBag.won = "You won : " + Betamount;
                ViewBag.Totalamount = "Total Profit : " + leftAmount;
            }
            else if (playerValue > 21)
            {
                ViewBag.winner = "Player Busted -- Dealer Won !!!";
                ViewBag.loose = "Amount Loose : " + Betamount;
                ViewBag.Totalamount = "Total Profit : " + leftAmount;
                Betamount = 0;
            }

            return View("Game");

        }

        /// <summary>
        /// Stand button, to let dealer distribute card for himself.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Stand()
        {
            ViewBag.Total = leftAmount;
            ViewBag.Amount = Betamount;

            while (dealerValue <=17)
            {
                dealerCard.Add(freshDeck.Cards[deckIndex]);
                dealerValue = dealerValue + freshDeck.Cards[deckIndex].Value;
                deckIndex++;

            }
            if(dealerValue > 21)
            {
                leftAmount = leftAmount + 2 * Betamount;
                ViewBag.winner = "Dealer Busted -- Player Won !!!";
                ViewBag.won = "You won : " + Betamount;
                ViewBag.Totalamount = "Total Profit : " + leftAmount;
            }

            else if(dealerValue > playerValue)
            {
                ViewBag.winner = "Player Busted -- Dealer Won !!!";
                ViewBag.loose = "Amount Loose : " + Betamount;
                ViewBag.Totalamount = "Total Profit : " + leftAmount;
                Betamount = 0;
            }

            ViewBag.playervalue = playerValue;
            ViewBag.dealervalue = dealerValue;

            ViewBag.displayPCard0 = playerCard[0];
            ViewBag.displayPCard1 = playerCard[1];
            //ViewBag.displayPCard2 = playerCard[2];
            

            ViewBag.displayDCard0 = dealerCard[0];
            ViewBag.displayDCard1 = dealerCard[1];
            ViewBag.displayDCard2 = dealerCard[2];
            

            return View("Game");
        }


        /// <summary>
        /// Play Again to start the game from starting
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Play_Again()
        {
            Deck freshDeck = new Deck();

            List<Card> playerCard = new List<Card>();
            List<Card> dealerCard = new List<Card>();
            playerCard.Clear();
            dealerCard.Clear();
            playerValue = 0;
            dealerValue = 0;
            deckIndex = 0;

            return View("Game");
        }

    }
}