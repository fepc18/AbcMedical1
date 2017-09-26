app.factory('memory', [ '$filter',
    function ( $filter) {

        var r = {
            storage: {
                get: function (item) {
                    var s = localStorage.getItem(item);
                    return s ? JSON.parse(localStorage.getItem(item)) : null;
                },
                set: function (item, value) {
                    localStorage.setItem(item, JSON.stringify(value));
                },
                clearItem: function (item) {
                    localStorage.removeItem(item);
                },
                clearAll: function () {
                    localStorage.clear();
                }
            }            
        }

        return r;
    }]);