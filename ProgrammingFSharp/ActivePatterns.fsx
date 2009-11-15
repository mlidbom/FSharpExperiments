#r "System.Xml.dll"
open System.Xml
let (|Elem|_|) name (inp:XmlNode) = 
    if inp.Name = name then Some(inp)
    else None

let (|Attributes|) (inp : XmlNode) = inp.Attributes

let (|Attr|) attrName (inp: XmlAttributeCollection) = 
    match inp.GetNamedItem(attrName) with
    | null -> failwithf "Attribute %s not found" attrName
    | attr -> attr.Value

type Part =
    | Widget of float
    | Sprocket of string * int

let ParseXmlNode element = 
    //Parse a widget without nesting active patterns
    match element with
    | Elem "Widget" xmlElement
        -> match xmlElement with
            | Attributes xmlElementsAttributes
                -> match xmlElementsAttributes with
                    | Attr "Diameter" diameter
                        -> Widget(float diameter)
    | Elem "Sprocket" (Attributes (Attr "Model" model & Attr "SerialNumber" sn))
        -> Sprocket(model, int sn)
    | _ -> failwith "Unknown element"

let ParseXmlNode2 element = 
    //Parse a widget without nesting active patterns
    match element with
    | Elem "Widget" (Attributes (Attr "Diameter" diameter)) 
        -> Widget(float diameter)
    | Elem "Sprocket" (Attributes (Attr "Model" model & Attr "SerialNumber" sn))
        -> Sprocket(model, int sn)
    | _ -> failwith "Unknown element"

let xmlDoc =
    let doc = new XmlDocument()
    let xmlText = 
        "<?xml version=\"1.0\" encoding=\"utf-8\"?>
        <Parts>
            <Widget Diameter='5.0' />
            <Sprocket Model='A' SerialNumber='147' />
            <Sprocket Model='B' SerialNumber='302' />
        </Parts>
        "
    doc.LoadXml(xmlText)
    doc

xmlDoc.DocumentElement.ChildNodes |> Seq.cast<XmlElement> |> Seq.map ParseXmlNode
xmlDoc.DocumentElement.ChildNodes |> Seq.cast<XmlElement> |> Seq.map ParseXmlNode2