// dummy.test.js
describe('Jest Test Suite', () => {
    test('should confirm Jest is working correctly', () => {
        const expected = true;
        const actual = true;
        expect(actual).toBe(expected);
    });

    test('should perform a simple arithmetic operation', () => {
        const sum = 2 + 2;
        expect(sum).toBe(4);
    });
});