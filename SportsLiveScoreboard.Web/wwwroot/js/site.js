// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

Object.defineProperty(Object.prototype, "forAll", {
    value: function forAll(action) {
        for (let i = 0; i < this.length; i++) {
            action(this[i]);
        }
    },
    writable: true,
    configurable: true
});