Things to mention in features.

1.) All data consolidated to have a minimal footprint.  I consolidate into almost a single data structure.  
It should be easy for my viewmodel to grab final data and transform where needed to make data viewable.  
Many small local variables or surprise global variables, or session state variables should not scatter 
data throughout the program. One data structure of properties and collections in nested classes and collections.
The services involved will operate on the data structure but connection of data should be contiguous for future 
programmers to quickly discover and make quick use.  Also lends itself to rapid scalabilty.

2.) Classes of consolidated error messages and user prompts/responses makes for a single point of change for 
updating messages while providing the orderability and consistency of an enum.  You don't have to search
through code to make updates.  One place and done.  Also lends itself to quick scalability

3.) Small service classes are data aware and are inteface injected into one another and the view model for decoupling 
and are unit test friendly.  This keeps logic simple and code easy to read.  
S in SOLID is Single Responsibilty Principle.

4.) I avoided using a command line program because I felt that numerous status messages would be overwhelming and 
distracting.  The score card is reporting on what has happened.  That should be enough and reposing a full 
card structure on the command line is actually almost as complicated as a more complicated interface.  
I did COBOL layout sheets in class years ago where you counted your boxes to layout your command line interface 
characters one space at a time.  No more please!

5.) I am more familiar with CORE for the web than CORE for WPF.  I have programmed .Net for Xamarin(MVVM)
and some WPF, however .Net is going away and conversion to core is part of your interest in me as I understand it. 
For this reason you will see that I like to use viewmodels in my MVC applications much like my MVVM applications.
I am used to tossing up ready made structures in a single view to bind to rather than massaging database models 
into view friendly data.  Things like dates, times, numeric values that represent a status, etc. should not 
have embedded logic in Razor or Javascript. Separation of the view from the logic and model was the point of 
MVC and MVVM.

6.) I believe in putting default values in the MODEL to avoid null exceptions. I don't use nullable types
except for database entities.  All internal data structures should take responsibilty for their own empty 
collections and strings, which are the only nullable types I use outside of database entities.  When it falls on 
code to check for all nulls things get missed.  When a parent class or collection is null and a child is called, 
we get a null exception.  We should be able to look at the model and assign default empty types that will not could 
for data but still be valid.  This is usually empty strings and empty collections.  Some people do this in constructor 
I have found that you can assign defaults to properies with {} = String.Empty to avoid this and be more obvious what 
is going on to the next programmer.