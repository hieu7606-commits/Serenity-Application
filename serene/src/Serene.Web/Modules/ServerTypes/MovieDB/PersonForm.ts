import { DateEditor, EnumEditor, initFormType, IntegerEditor, PrefixedContext, StringEditor } from "@serenity-is/corelib";
import { Gender } from "./Gender";

export interface PersonForm {
    FirstName: StringEditor;
    LastName: StringEditor;
    BirthDate: DateEditor;
    BirthPlace: StringEditor;
    Gender: EnumEditor;
    Height: IntegerEditor;
}

export class PersonForm extends PrefixedContext {
    static readonly formKey = 'MovieDB.Person';
    declare private static init: boolean;

    constructor(...args: ConstructorParameters<typeof PrefixedContext>) {
        super(...args);

        if (!PersonForm.init) {
            PersonForm.init = true;

            initFormType(PersonForm, [
                'FirstName', StringEditor,
                'LastName', StringEditor,
                'BirthDate', DateEditor,
                'BirthPlace', StringEditor,
                'Gender', EnumEditor,
                'Height', IntegerEditor
            ]);
        }
    }
}

[Gender]; // referenced types