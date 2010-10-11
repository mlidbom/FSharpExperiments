[<System.Runtime.CompilerServices.Extension>]    
module Exts.CollectionExtensions
  //Extension method
    [<System.Runtime.CompilerServices.Extension>]    
    let IsNullOrWhiteSpace this = System.String.IsNullOrWhiteSpace this
    
    //Static extension method
    [<System.Runtime.CompilerServices.Extension>]    
    let MyLength (aString:string) = aString.Length





//[<System.Runtime.CompilerServices.Extension>]    
//module Extensions.String
//
//[<System.Runtime.CompilerServices.Extension>]    
//let IsNullOrWhiteSpace this = System.String.IsNullOrWhiteSpace this
//
//
//
//
//
