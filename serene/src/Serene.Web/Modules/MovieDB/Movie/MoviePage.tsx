/**
 * The browser entry point for the Movie screen - the module MoviePage.cs names in its
 * GridPage("@/MovieDB/Movie/MoviePage") call.
 *
 * gridPageInit waits for the page to be ready, creates a MovieGrid and drops it into the container
 * the server rendered. Nothing else belongs here: the grid is where the screen's behaviour lives,
 * and this file only starts it.
 */
import { gridPageInit } from '@serenity-is/corelib';
import { MovieGrid } from './MovieGrid';

export default () => gridPageInit(MovieGrid);