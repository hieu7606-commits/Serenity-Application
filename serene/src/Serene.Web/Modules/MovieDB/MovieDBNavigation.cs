// The sidebar entries for this module. Navigation is declared as assembly attributes rather than a
// list in one shared file, so a module brings its own menu items with it and nothing central has to
// be edited to add or remove a screen.
using Serenity.Navigation;
using MyPages = Serene.MovieDB.Pages;

// Arguments: sort order, then "Section/Item" - the slash is what puts Movie under a MovieDB
// heading. The page type supplies both the URL and the permission, so an entry never outlives the
// page or shows to someone who cannot open it.
//
// int.MaxValue keeps this last in the sidebar; give it a smaller number to move it up, and pass an
// icon such as "fa-film" in place of null to replace the default bullet.
[assembly: NavigationLink(int.MaxValue, "MovieDB/Movie", typeof(MyPages.MoviePage), icon: null)]