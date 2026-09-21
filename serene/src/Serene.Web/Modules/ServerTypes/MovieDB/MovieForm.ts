import { PrefixedContext, initFormType, StringEditor, IntegerEditor, DateEditor } from '@serenity-is/corelib';

export interface MovieForm {
    Title: StringEditor;
    Description: StringEditor;
    Storyline: StringEditor;
    Year: IntegerEditor;
    ReleaseDate: DateEditor;
    Runtime: IntegerEditor;
}

export class MovieForm extends PrefixedContext {
    static readonly formKey = 'MovieDB.Movie';
    private static init: boolean;
    
    constructor(...args: ConstructorParameters<typeof PrefixedContext>) {
        super(...args);

        if (!MovieForm.init)  {
            MovieForm.init = true;

            initFormType(MovieForm, [
                'Title', StringEditor,
                'Description', StringEditor,
                'Storyline', StringEditor,
                'Year', IntegerEditor,
                'ReleaseDate', DateEditor,
                'Runtime', IntegerEditor,
            ]);
        }
    }
}