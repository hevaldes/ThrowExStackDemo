# Rethrow to preserve stack details

Guideline

Once an exception is thrown, part of the information it carries is the stack trace. The stack trace is a list of the method call hierarchy that starts with the method that throws the exception and ends with the method that catches the exception. If an exception is re-thrown by specifying the exception in the throw statement, the stack trace is restarted at the current method and the list of method calls between the original method that threw the exception and the current method is lost. To keep the original stack trace information with the exception, use the throw statement without specifying the exception.
The following example shows a method, CatchAndRethrowExplicitly, which violates the rule and a method, CatchAndRethrowImplicitly, which satisfies the rule.

```
using System;  

namespace UsageLibrary  
{  
   class TestsRethrow  
   {  
      static void Main()  
      {  
         TestsRethrow testRethrow = new TestsRethrow();  
         testRethrow.CatchException();  
      }  

      void CatchException()  
      {  
         try  
         {  
            CatchAndRethrowExplicitly();  
         }  
         catch(ArithmeticException e)  
         {  
            Console.WriteLine("Explicitly specified:{0}{1}",   
               Environment.NewLine, e.StackTrace);  
         }  

         try  
         {  
            CatchAndRethrowImplicitly();  
         }  
         catch(ArithmeticException e)  
         {  
            Console.WriteLine("{0}Implicitly specified:{0}{1}",   
               Environment.NewLine, e.StackTrace);  
         }  
      }  

      void CatchAndRethrowExplicitly()  
      {  
         try  
         {  
            ThrowException();  
         }  
         catch(ArithmeticException e)  
         {  
            // Violates the rule.  
            throw e;  
         }  
      }  

      void CatchAndRethrowImplicitly()  
      {  
         try  
         {  
            ThrowException();  
         }  
         catch(ArithmeticException e)  
         {  
            // Satisfies the rule.  
            throw;  
         }  
      }  

      void ThrowException()  
      {  
         throw new ArithmeticException("illegal expression");  
      }  
   }  
}  

```
