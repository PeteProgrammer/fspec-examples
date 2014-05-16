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
          let account = ctx |> getSubject<Account>
          account.Balance <- 500)

        it "account dispenses cash" (fun ctx ->
          let account = ctx |> getSubject<Account>
          account.CanWithdraw(60) |> should (be.equalTo true)
        )
      ]
          
      context "account is overdrawn" [
        before (fun ctx -> 
          let account = ctx |> getSubject<Account>
          account.Balance <- -500)

        it "the Account does not dispense cash" (fun ctx ->
          let account = ctx |> getSubject<Account>
          account.CanWithdraw(60) |> should (be.equalTo false)
        )
      ]
    ]
  ]
