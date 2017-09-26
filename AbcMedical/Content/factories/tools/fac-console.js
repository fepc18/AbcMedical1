app.factory('trace', ['$log',
    function ($log) {
        var local = {
            proccess: function (message, type) {
                var log = "";
                var pret = "";
                var msgSimple = message.replace(/<(?:.|\n)*?>/gm, '');

                switch (type.toUpperCase()) {
                    case "E":
                        log = "500 - " + msgSimple;
                        pret = "Lo Sentimos!: ";
                        $log.error(log || "500 - ");
                        break;
                    case "I":
                        log = "200 - " + msgSimple;
                        pret = "Finalizado!: ";
                        $log.info(log || "200 - ");
                        break;
                    case "W":
                        log = "100 - " + msgSimple;
                        pret = "Advertencia!: ";
                        $log.warn(log || "100 - ");
                        break;
                }                
                return {
                    log: log,
                    pretty: pret + message
                }
            }
        }
        var r = {
            print:{
                error: function (message) {
                    message = message.toString();
                    return local.proccess(message, "E");
                },
                warning: function (message) {
                    message = message.toString();
                    return local.proccess(message, "W");
                },
                info: function (message) {
                    message = message.toString();
                    return local.proccess(message, "I");
                },
            },            
        }

        return r;
    }]);