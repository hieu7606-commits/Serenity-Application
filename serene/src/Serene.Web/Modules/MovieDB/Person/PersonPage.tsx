/**
 * The browser entry point for the Person screen - the module PersonPage.cs names in its GridPage
 * call. It only starts the grid.
 */
import { gridPageInit } from '@serenity-is/corelib';
import { PersonGrid } from './PersonGrid';

export default () => gridPageInit(PersonGrid);
