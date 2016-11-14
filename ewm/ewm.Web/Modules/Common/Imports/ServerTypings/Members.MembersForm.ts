

namespace ewm.Members {
    export class MembersForm extends Serenity.PrefixedContext {
        static formKey = 'Members.Members';
    }

    export interface MembersForm {
        PhoneNumber: Serenity.StringEditor;
        Username: Serenity.StringEditor;
        FirstName: Serenity.StringEditor;
        LastName: Serenity.StringEditor;
    }

    [['PhoneNumber', () => Serenity.StringEditor], ['Username', () => Serenity.StringEditor], ['FirstName', () => Serenity.StringEditor], ['LastName', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(MembersForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}