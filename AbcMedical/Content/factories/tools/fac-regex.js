app.factory('regex', function () {
    var r = {
        match: {
            autocomplete: {
                description: "Valor ingresado no existe en la lista."
            }
        },
        minlength: {
            description: function (l) {
                return "No debe ser menor a " + l + " caracteres."
            }
        },
        maxlength: {
            description: function (l) {
                return "No debe ser mayor a " + l + " caracteres."
            },
            descriptionCurrency: function (l) {
                return "No debe ser mayor a " + l + " dígitos."
            },
            lCurrency: function (l) {                
                var count = l;
                var sum = 0;

                do {                    
                    aux = count % 3;                    
                    if (aux != 0) count += 1;
                } while (aux != 0);
                sum = count / 3;
            
                l = l + sum;

                return l;
            }
        },
        pattern: {
            description: "Formato incorrecto."
        },
        required: {
            description: "Requerido."
        },
        cellNumber: {
            value: /(^3+[0-2,5]{1}[0-9]{8})\b/,
            description: "Teléfono Celular inválido. (ej: 300*, 310*, 320*, 350*)"
        },
        phoneNumber: {
            value: /(^[0-9]{7})\b/,
            description: "Teléfono inválido."
        },
        otpCode: {
            value: /(^[0-9]{6}\b)/,
            description: "Código OTP inválido."
        },
        letters: {
            all: {
                value: /^[-+#*.0-9a-zA-ZáéíóúñÁÉÍÓÚÑ ]*$/,
                description: "Caracter no reconocido en el texto ingresado."
            },
            general: {
                value: /^[a-zA-ZáéíóúñÁÉÍÓÚÑ ]*$/,
                description: "Debe contener sólo letras y/o espacios."
            },
            closed: {
                value: /^[a-zA-ZáéíóúñÁÉÍÓÚÑ]*$/,
                description: "Debe contener sólo letras."
            },
            alphaNumeric: {
                value: /^[0-9a-zA-Z]*$/,
                description: "Debe contener sólo letras y números."
            }
        },
        basic: {
            value: /^[0-9a-zA-ZáéíóúñÁÉÍÓÚÑ ]*$/,
            description: "Debe contener sólo números, letras y/o espacios"
        },
        numeric: {
            value: /^[0-9]*$/,
            description: "Debe contener sólo números."
        },
        email: {
            general: {
                value: /^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$/,
                description: "Correo electrónico inválido."
            },
            whole: {
                name: {
                    value: /^(?!.*notiene)(?!.*nada)(?!.*no tiene)(^[^0-9]{1})([a-zA-Z0-9]){2,50}/,
                    description: "El nombre de correo debe ser mayor a dos caracteres y no debe tener la palabra 'no tiene' o 'nada'",
                },
                domain: {
                    value: /^(?!.*notiene)(?!.*nada)(?!.*no tiene)(^[^0-9]{1})((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,4}))$/,
                    description: "El dominio de correo debe tener un formato correcto (Ej: dominio.abc), ser mayor a dos caracteres y no tener la palabra 'no tiene' o 'nada'",
                }
            },
        },
    };

    return r;
});