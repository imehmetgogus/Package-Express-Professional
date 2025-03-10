using System;

namespace PackageExpress
{
    /// <summary>
    /// Main program class for Package Express shipping calculator
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Create new shipping calculator instance
            ShippingCalculator calculator = new ShippingCalculator();
            
            // Run the calculator
            calculator.CalculateShipping();
            
            // Keep console window open
            Console.ReadLine();
        }
    }
    
    /// <summary>
    /// Class that handles shipping calculations
    /// </summary>
    class ShippingCalculator
    {
        // Constants
        private const float MAX_WEIGHT = 50.0f;
        private const float MAX_TOTAL_DIMENSIONS = 50.0f;
        private const float QUOTE_DIVISOR = 100.0f;
        
        // Package properties
        private float packageWeight;
        private float packageWidth;
        private float packageHeight;
        private float packageLength;
        
        /// <summary>
        /// Main method to run the shipping calculation process
        /// </summary>
        public void CalculateShipping()
        {
            DisplayWelcome();
            
            // Get and validate package weight
            GetPackageWeight();
            if (packageWeight > MAX_WEIGHT)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                return;
            }
            
            // Get package dimensions
            GetPackageDimensions();
            
            // Check if package is too large
            if (IsTooLarge())
            {
                Console.WriteLine("Package too big to be shipped via Package Express.");
                return;
            }
            
            // Calculate and display the shipping quote
            DisplayShippingQuote();
        }
        
        /// <summary>
        /// Displays welcome message
        /// </summary>
        private void DisplayWelcome()
        {
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");
        }
        
        /// <summary>
        /// Gets package weight from user
        /// </summary>
        private void GetPackageWeight()
        {
            Console.WriteLine("Please enter the package weight:");
            packageWeight = float.Parse(Console.ReadLine());
        }
        
        /// <summary>
        /// Gets all package dimensions from user
        /// </summary>
        private void GetPackageDimensions()
        {
            Console.WriteLine("Please enter the package width:");
            packageWidth = float.Parse(Console.ReadLine());
            
            Console.WriteLine("Please enter the package height:");
            packageHeight = float.Parse(Console.ReadLine());
            
            Console.WriteLine("Please enter the package length:");
            packageLength = float.Parse(Console.ReadLine());
        }
        
        /// <summary>
        /// Checks if package dimensions exceed maximum allowed
        /// </summary>
        /// <returns>True if package is too large, otherwise false</returns>
        private bool IsTooLarge()
        {
            return packageWidth + packageHeight + packageLength > MAX_TOTAL_DIMENSIONS;
        }
        
        /// <summary>
        /// Calculates and displays the shipping quote
        /// </summary>
        private void DisplayShippingQuote()
        {
            // Calculate quote
            float quote = (packageWidth * packageHeight * packageLength * packageWeight) / QUOTE_DIVISOR;
            
            // Display quote to user
            Console.WriteLine($"Your estimated total for shipping this package is: ${quote:F2}");
            Console.WriteLine("Thank you!");
        }
    }
}