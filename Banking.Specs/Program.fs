﻿// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    System.Reflection.Assembly.GetExecutingAssembly ()
    |> FSpec.Core.TestDiscovery.runSingleAssembly