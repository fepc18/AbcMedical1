app.factory('navigation', ['paramsPromise', '$filter', '$rootScope', '$location',
    function (paramsPromise, $filter, $rootScope, $location) {

        var r = {
            navigate: {
                getPath: function () {
                    return $location.path();
                },
                go: function (link, changeTitle) {
                    $location.path(link);
                    $location.url($location.path());
                    if (changeTitle) $rootScope.titleApp = "Admisiones Web";
                },
                include: function (sectionName) {
                    $rootScope.sectionInclude = sectionName;
                    //$location.path(link);
                },
                title: function (text) {                   
                    $rootScope.titleApp = text || "Admisiones Web";
                }
            },

        }

        return r;
    }]);