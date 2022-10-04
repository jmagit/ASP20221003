$.validator.addMethod('nif', function (value, element, params) {
    var nif = value;

    if (!/^\d{1,8}[A-Za-z]$/.test(nif))
        return false;
    const letterValue = nif.substr(nif.length - 1);
    const numberValue = nif.substr(0, nif.length - 1);
    return letterValue.toUpperCase() === 'TRWAGMYFPDXBNJZSQVHLCKE'.charAt(numberValue % 23);

});

$.validator.unobtrusive.adapters.add('nif', ['year'], function (options) {
    options.rules['nif'] = {};
    options.messages['nif'] = options.message;
});
