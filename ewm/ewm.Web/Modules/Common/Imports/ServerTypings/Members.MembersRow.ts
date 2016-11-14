
namespace ewm.Members {
    export interface MembersRow {
        Id?: number;
        PhoneNumber?: string;
        Username?: string;
        FirstName?: string;
        LastName?: string;
    }

    export namespace MembersRow {
        export const idProperty = 'Id';
        export const nameProperty = 'PhoneNumber';
        export const localTextPrefix = 'Members.Members';

        export namespace Fields {
            export declare const Id;
            export declare const PhoneNumber;
            export declare const Username;
            export declare const FirstName;
            export declare const LastName;
        }

        ['Id', 'PhoneNumber', 'Username', 'FirstName', 'LastName'].forEach(x => (<any>Fields)[x] = x);
    }
}

