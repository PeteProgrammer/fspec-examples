module AccountSpec
open Banking
open FSpec.Core
open Dsl
open MatchersV3
open TestContextOperations

let specs =
  describe "Account" [
    subject (fun _ -> new Account())

    context "when withdrawing cash" [
      context "account is in balance" [
        before (fun ctx -> 
            ctx.GetSubject<Account>().Balance <- 500)

        it "account dispenses cash" (fun ctx ->
          ctx.GetSubject<Account>().CanWithdraw(60).Should be.True
        )
      ]
          
      context "account is overdrawn" [
        before (fun ctx -> 
            ctx.GetSubject<Account>().Balance <- -500)

        it "the Account does not dispense cash" (fun ctx ->
          ctx.GetSubject<Account>().CanWithdraw(60).Should be.False
        )
      ]
    ]
  ]
