// The sidebar entries for this module. Navigation is declared as assembly attributes rather than a
// list in one shared file, so a module brings its own menu items with it and nothing central has to
// be edited to add or remove a screen.
using Serenity.Navigation;
using MyPages = Serene.MovieDB.Pages;

// Declaring the section explicitly is what lets it have its own order and icon; an implicit one
// takes the lowest order of its children and no icon. 6000 places it above Northwind (7000) and
// Administration (9000).
[assembly: NavigationMenu(6000, "Movie Database", icon: "fa-film")]

// Arguments: sort order, then "Section/Item" - the slash is what puts Movies under the Movie
// Database heading. The page type supplies both the URL and the permission, so an entry never
// outlives the page or shows to someone who cannot open it.
//
// The order only ranks this link among its siblings in the section, not across the whole sidebar.
[assembly: NavigationLink(6100, "Movie Database/Movies", typeof(MyPages.MoviePage), icon: "fa-video-camera")]
[assembly: NavigationLink(6200, "Movie Database/Genres", typeof(MyPages.GenrePage), icon: "fa-thumb-tack")]
[assembly: NavigationLink(6300, "Movie Database/Person", typeof(MyPages.PersonPage), icon: "fa-users")]