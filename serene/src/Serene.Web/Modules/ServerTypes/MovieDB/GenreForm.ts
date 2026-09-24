import { initFormType, PrefixedContext, StringEditor } from "@serenity-is/corelib";

export interface GenreForm {
    Name: StringEditor;
}

export class GenreForm extends PrefixedContext {
    static readonly formKey = 'MovieDB.Genre';
    declare private static init: boolean;

    constructor(...args: ConstructorParameters<typeof PrefixedContext>) {
        super(...args);

        if (!GenreForm.init) {
            GenreForm.init = true;

            initFormType(GenreForm, [
                'Name', StringEditor
            ]);
        }
    }
}