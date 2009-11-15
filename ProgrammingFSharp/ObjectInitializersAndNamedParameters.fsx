type Person(foreName : string, surName: string)=
    let mutable m_foreName = foreName
    let mutable m_surName = foreName
    
    let mutable m_mother:Option<Person>  = None
    let mutable m_father:Person option  = None
    
    member this.ForeName with get()  = m_foreName and set(value) = m_foreName <- value
    member this.SurName with get() = m_surName and set(value) = m_surName <- value        
    member this.Mother with get() = m_mother and set(value) = m_mother <- value
    member this.Father with get() = m_father and set(value) = m_father <- value

    member this.SetName(surName:string, foreName:string) = 
        m_foreName <- foreName
        m_surName <- surName
    new () = new Person("", "")

    override this.ToString() = sprintf "%s %s" this.ForeName this.SurName

let magnusLidbomViaNamedParams = new Person(surName = "Lidbom", foreName = "Magnus")
let magnusLidbomViaInitializerExpression = 
    new Person(SurName = "Lidbom", ForeName = "Magnus", 
        Mother=Some(new Person(ForeName="Eva", SurName="Lidbom")),
        Father=Some(new Person(ForeName="Lars", SurName="Lidbom")))

let magnusLidbomViaSetName = new Person()
magnusLidbomViaSetName.SetName("Lidbom", "Magnus") 
magnusLidbomViaSetName.Mother = Some(new Person("Eva", "Lidbom"))



