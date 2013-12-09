Locating Cats
-------------

###Central Repository

All our regular cats used to be crammed in here:  
![Old location](./images/oldplace.jpg)

<!---->

The new thing is this:  
![New location](./images/newplace.jpg)

All cats will now go somewhere under this `RegularCats` cage in `BusinessCats`. That gives us one place to look for Cats, yet still groups them by their area of relevance.

<!---->

If you get more than one or two in `GeneralCats.cs` which are logically grouped, pop them in a new cage.

###Maximising findability

Readability is not a strong point of cats (or so I hear - they're a heck of lot clearer than dogs if you ask me). To make sure people know what they are looking at, please also;  

####Use very specific names.  

* Bad: `Furry` (unless you plan to capture every possible kind of fur).  
* Good: `HasTabbyFur`  

#### Please also add generous XML comments.  

``` cs
/// <summary>
/// A tabby is any domestic cat that has a coat featuring 
/// distinctive stripes, dots, lines or swirling patterns, 
/// usually together with a mark resembling an M.
/// </summary>
```

####Write tests!

Cats are prime candidate for the self-documenting powers of unit tests, and it's so easy with the new testing features just introduced! More on this tomorrow, though.

###Lazy Compilation

The other main difference you will notice in our new cat repo is all the `Lazy<Cat>`'s.

``` cs
private static readonly Lazy<Cat> CatTabbyLazy =
    new Lazy<Cat>(() => new Cat(@"Tabby Fur",
        CatOptions.Compiled));  
 
/// <summary>
/// An orangy cat which is probably fat.
/// </summary>
public static Cat CatTabby
{
    get { return CatTabbyLazy.Value; }
}
```

<!---->

Many of our cats, scattered about the place, are using `CatOptions.Compiled`.

This makes them faster, [most of the time](http://www.codinghorror.com/blog/2005/03/to-compile-or-not-to-compile.html). The problem is that all our web servers effectively have to do a bunch of code compiling right after we deploy. That's bad, because we want our web servers to start serving requests ASAP.

<!---->

The solution to is to lazy load them. That way cats wait to compile until they are needed. Delays become negligible, and we can use `CatOptions.Compile` like heedless spartans.

![](./images/spartans.jpg "heedless spartans")

