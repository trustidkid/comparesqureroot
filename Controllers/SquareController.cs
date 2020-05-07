using System.Threading.Tasks.Dataflow;
using System;
using Microsoft.AspNetCore.Mvc;

namespace CompareSquareRoot.Controllers
{
    public class SquareController : Controller{
        [HttpGet]
        public IActionResult Compare()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Compare(string firstnumber, string secondnumber){

            /*
                "The number 16 with Square root 4 has a higher square root than the number 4 
                with square root 2"

                If the numbers have the same square root, the system should inform 
                the user and ask them to enter another value. 

                If the value entered is not a number, an error message should be displayed for the user.

                If a negative number is entered, an error message should be displayed.
             */

            int number;
            //check that user enter number
            if(String.IsNullOrWhiteSpace(firstnumber) || String.IsNullOrWhiteSpace(secondnumber)){
                ViewBag.Result = "All fields must be filled. Thank you";
            }
            else
            {
                int firstSquare =0; 
                int secondSquare = 0; 
                double squareOne = 0.0; 
                double squareTwo =0.0;

                //check if user enter character instead of a number
                if(!int.TryParse(firstnumber, out number) || !int.TryParse(secondnumber, out number)){
                    ViewBag.Result = "Input number(s) contain character value. Please enter another number";
                }else{

                    firstSquare = int.Parse(firstnumber);
                    secondSquare = int.Parse(secondnumber);

                    squareOne = Math.Sqrt(firstSquare);
                    squareTwo = Math.Sqrt(secondSquare);

                    //check negative value
                    if(firstSquare < 0 || secondSquare < 0){
                        ViewBag.Result = "Negative value is not allowed here. Thank you";
                    }
                
                    //compare the square of the two values
                    else if(squareOne == squareTwo){ 
                        ViewBag.Result = "The square root of the two numbers are the same. Please enter another value";
                    }
                    else if(squareOne > squareTwo){
                        ViewBag.Result = "The number "+ firstSquare + " with Square root of " + squareOne + 
                        " has a higher square root than the number " +
                        secondSquare + " with square root of "+ squareTwo;
                        
                    }else{
                        ViewBag.Result = "The number "+ secondSquare + " with Square root of " + squareTwo + 
                        " has a higher square root than the number " +
                        firstSquare + " with square root of "+ squareOne;
                    }
                }
                
                
            }
            return View();
            
        }
    }
}