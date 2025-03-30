module.exports = {
    moduleFileExtensions: ['js', 'json', 'vue'],
    moduleDirectories: ['node_modules', '<rootDir>'],
    transform: {
        '^.+\\.vue$': '@vue/vue3-jest', // or '@vue/vue2-jest' for Vue 2
        '^.+\\.js$': 'babel-jest',
    },
    testEnvironment: 'jsdom',
};