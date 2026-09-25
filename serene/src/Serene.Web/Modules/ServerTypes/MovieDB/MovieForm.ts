import { DateEditor, EnumEditor, initFormType, IntegerEditor, LookupEditor, PrefixedContext, StringEditor, TextAreaEditor } from "@serenity-is/corelib";
import { MovieCastEditor } from "../../MovieDB/MovieCast/MovieCastEditor";
import { MovieKind } from "./MovieKind";

export interface MovieForm {
    Title: StringEditor;
    Description: TextAreaEditor;
    CastList: MovieCastEditor;
    Storyline: TextAreaEditor;
    Year: IntegerEditor;
    ReleaseDate: DateEditor;
    Runtime: IntegerEditor;
    Kind: EnumEditor;
    GenreList: LookupEditor;
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
                'CastList', MovieCastEditor,
                'Storyline', TextAreaEditor,
                'Year', IntegerEditor,
                'ReleaseDate', DateEditor,
                'Runtime', IntegerEditor,
                'Kind', EnumEditor,
                'GenreList', LookupEditor
            ]);
        }
    }
}

[MovieKind]; // referenced types