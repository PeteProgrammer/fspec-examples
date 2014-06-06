module AccountingSpecV3
open Banking
open FSpec.Core
open Dsl
open MatchersV3
open TestContextOperations

// Add extension methods to the test context to
// help the tests become easier to read
type TestContext
  with
    member self.Account 
      with get() : Account = self?account
      and set account = self?account <- account

let specs =
  describe "Account" [
    before (fun ctx -> 
      ctx.Account <- new Account()
      ctx.Account.Balance <- ctx.metadata?initial_balance)

    describe ".CanWithdraw()" [
      subject (fun ctx -> 
        ctx.Account.CanWithdraw(60))

      ("initial_balance" ++ 500) ==>
      context "when account is in balance" [
        itShould be.True
      ]
      
      ("initial_balance" ++ -500) ==>
      context "when account is overdrawn" [
        itShould be.False
      ]
    ]
  ]
