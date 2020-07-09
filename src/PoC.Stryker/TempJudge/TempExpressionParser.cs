using System;
using TempJudge.Domain;

namespace TempJudge
{
    public class TempExpressionParser
    {
        public TempCategory ParseToTempCategory(string response)
        {            
            try
            {
                return response switch
                {
                    var x when
                        x == "warm" ||
                        x == "hot" => TempCategory.Warm,

                    var x when
                        x == "cool" ||
                        x == "fresh" => TempCategory.Fresh,

                    var x when
                        x == "cold" ||
                        x == "chilly" => TempCategory.Cold,

                    var x when
                        x == "freezing" ||
                        x == "frozen" => TempCategory.Freezing,
                    
                    _ => throw new ArgumentOutOfRangeException(message: "Invalid response", paramName: nameof(response)),
                };
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Expression in response is not recognized.", ex);
                throw;
            }
        }
    }
}
