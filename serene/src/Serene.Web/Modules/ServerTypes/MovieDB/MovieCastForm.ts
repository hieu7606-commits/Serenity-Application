import { initFormType, LookupEditor, PrefixedContext, StringEditor } from "@serenity-is/corelib";

export interface MovieCastForm {
    PersonId: LookupEditor;
    Character: StringEditor;
}

export class MovieCastForm extends PrefixedContext {
    static readonly formKey = 'MovieDB.MovieCast';
    declare private static init: boolean;

    constructor(...args: ConstructorParameters<typeof PrefixedContext>) {
        super(...args);

        if (!MovieCastForm.init) {
            MovieCastForm.init = true;

            initFormType(MovieCastForm, [
                'PersonId', LookupEditor,
                'Character', StringEditor
            ]);
        }
    }
}