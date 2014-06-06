module Main

[<EntryPoint>]
let main argv = 
    System.Reflection.Assembly.GetExecutingAssembly ()
    |> FSpec.Core.TestDiscovery.runSingleAssembly