module AccountingSpecV2
open Banking
open FSpec.Core
open Dsl
open MatchersV3
open TestContextOperations

type TestContext
    with
        member self.Account  
            with get() = self.Get<Account> "account"
            and set account = self.Set "account" account

let specs =
  describe "Account" [
    subject (fun ctx -> 
      ctx.Account <- new Account()
      ctx.Account.Balance <- ctx.metadata?initial_balance)

    describe ".CanWithdraw()" [
      subject (fun ctx -> 
        ctx.Account.CanWithdraw(60))
  
      ("initial_balance" ++ 500) ==>
      context "account is in balance" [
        it "account dispenses cash" (fun ctx ->
          ctx |> getSubject |> should (be.equalTo true)
        )
      ]
          
      ("initial_balance" ++ -500) ==>
      context "account is overdrawn" [
        it "the Account does not dispense cash" (fun ctx ->
          ctx |> getSubject |> should (be.equalTo false)
        )
      ]
    ]
  ]
