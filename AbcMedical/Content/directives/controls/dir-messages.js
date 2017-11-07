//  =           paso de variable directo
//  @           paso del valor de la variable
//  &           paso de funcion directo
// =NgModel     paso de variable (value) en ngModel directo

app.directive('messageCustom', ['$timeout', function ($timeout) {
    return {
        scope: {
            title: '@?title',
            message: '@?message',
            messageButton: '@?messageButton',
            funct: '&?funct',
            type: "@",
            big: "@?big",
            small: "@?small",
            popup: "@?popup",
            closing: "@?closing"
        },
        templateUrl: function (element, attr) {
            var tp = attr.type || "info";
            //var bg = attr.big ? "big-" : attr.small ? "min-" : "";
            var bg = attr.hasOwnProperty('big') ? "big-" : attr.hasOwnProperty('small') ? "min-" : "";

            return '/content/style/templates/' + bg + 'message-' + tp + '.html';
        },
        link: function (scope, element, attr) {
            scope.popup = attr.hasOwnProperty('popup') ? true : false;
            scope.closing = attr.hasOwnProperty('closing') ? true : false;
            
            function load(messageFromModel) {
                debugger;
                var isFunction = scope.funct ? true : false;
                var newKey = key();

                scope.data = {
                    title: scope.title || '',
                    message: scope.message || '',
                    messageButton: scope.messageButton || '',
                    isFn: isFunction,
                    popup: scope.popup,
                    closing: scope.closing,
                    key: newKey
                }

                if (scope.popup) {
                    $(".modal").attr("id", 'm' + newKey);
                    $('#m' + newKey).modal({ keyboard: false, backdrop: "static" });
                } else {
                    $(".modal").attr("id", '#m' + newKey);
                    $('#m' + newKey).css("display", "none");
                }
            }

            load();
            //$timeout(load, 0);

            function key() {
                var dat = new Date().getTime();
                var ran = Math.floor(Math.random() * (999 - 100)) + 100;
                var id = dat + ran;

                return id;
            }

        }
    };
}]);
