import { DateEditor, EnumEditor, initFormType, IntegerEditor, PrefixedContext, StringEditor, TextAreaEditor } from "@serenity-is/corelib";
import { MovieKind } from "./MovieKind";

export interface MovieForm {
    Title: StringEditor;
    Description: TextAreaEditor;
    Storyline: TextAreaEditor;
    Year: IntegerEditor;
    ReleaseDate: DateEditor;
    Runtime: IntegerEditor;
    Kind: EnumEditor;
}

export class MovieForm extends PrefixedContext {
    static readonly formKey = 'MovieDB.Movie';
    declare private static init: boolean;

    constructor(...args: ConstructorParameters<typeof PrefixedContext>) {
        super(...args);

        if (!MovieForm.init) {
            MovieForm.init = true;

            initFormType(MovieForm, [
                'Title', StringEditor,
                'Description', TextAreaEditor,
                'Storyline', TextAreaEditor,
                'Year', IntegerEditor,
                'ReleaseDate', DateEditor,
                'Runtime', IntegerEditor,
                'Kind', EnumEditor
            ]);
        }
    }
}

[MovieKind]; // referenced types