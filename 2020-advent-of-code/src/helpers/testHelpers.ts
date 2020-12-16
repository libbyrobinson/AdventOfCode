import { act } from "react-dom/test-utils"

export const assert = (value: any, expected: any) => {
    if(expected !== value) {
        throw Error(`Expected ${value} to be ${expected}`)
    }
}