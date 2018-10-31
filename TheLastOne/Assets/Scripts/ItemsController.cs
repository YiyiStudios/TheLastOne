using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    //Static means that it can be accessed without instantiating a class. This is good for constants
    //public: Public declared items can be accessed everywhere.
    /*
     public:    Public declared items can be accessed everywhere.
     protected: Protected limits access to inherited and parent classes 
                (and to the class that defines the item).
     private:   Private limits visibility only to the class that defines the item.
     static:    A static variable exists only in a local function scope,
                but it does not lose its value when program execution leaves this scope.
                ///////////////////////////////////////////////
                un método puede ser de instancia o de clase. Un método NO estático
                es un método de instancia (que necesita una instancia de la clase donde 
                se declara para ser invocado) y un método estático es un método de clase (sólo 
                se necesita invocarlo dada la clase, no un objeto de dicha clase).
     final:     Final keyword prevents child classes from overriding a method 
                by prefixing the definition with final. If the class itself is
                being defined final then it cannot be extended.
     transient: A transient variable is a variable that may not be serialized.
     volatile:  a variable that might be concurrently modified by multiple threads 
                should be declared volatile. Variables declared to be volatile will 
                not be optimized by the compiler because their value can change at any time.
    */
    public static GameObject item1;
    public  GameObject item2;
    static GameObject item3;
    public GameObject item4;
    public GameObject item5;



    void FirstButtonItem()
    {
        
    }
    void SecondButtonItem()
    {

    }
    void ThirdButtonItem()
    {

    }
}
