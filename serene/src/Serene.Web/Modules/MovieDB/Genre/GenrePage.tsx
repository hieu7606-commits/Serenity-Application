/**
 * The browser entry point for the Genres screen - the module GenrePage.cs names in its GridPage
 * call. It only starts the grid.
 */
import { gridPageInit } from '@serenity-is/corelib';
import { GenreGrid } from './GenreGrid';

export default () => gridPageInit(GenreGrid);
