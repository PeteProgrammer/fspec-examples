module AccountingSpecV2
open Banking
open FSpec.Core
open Dsl
open MatchersV3
open TestContextOperations

let specs =
  describe "Account" [
    subject (fun ctx -> 
      let account = new Account()
      account.Balance <- ctx.metadata?initial_balance
      account)

    describe ".CanWithdraw()" [
      subject (fun ctx -> ctx.GetSubject<Account>().CanWithdraw(60))

      ("initial_balance" ++ 500) ==>
      context "account is in balance" [
        it "account dispenses cash" <| fun ctx ->
          ctx.Subject.Should (be.True) 
      ]

      ("initial_balance" ++ -500) ==>
      context "account is overdrawn" [
        it "the Account does not dispense cash" <| fun ctx ->
          ctx.Subject.Should (be.False)
      ]
    ]
  ]
