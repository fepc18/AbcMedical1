app.factory('parametrics', ['memory', 'paramsPromise', '$filter', '$log',
    function (memory, paramsPromise, $filter, $log) {
        var local = {
            returnJsonPush: function (storageName, obj) {
                obj.splice(0, obj.length)

                var json = angular.fromJson(memory.storage.get(storageName));

                angular.forEach(json, function (item, index) {
                    obj.push(item);
                })
            },
            versionParams: 13,
        }
        var r = {
            state: false,
            products: [],
            enableCheckedsProduct: function () {                
                var parametricsprod = memory.storage.get("parametrics_productos");
                var parametricsprod_checkeds = memory.storage.get("product_available_checkeds");
                var filter = $filter("filter")(parametricsprod, { estado: "1" });
                var idx = 1;
                var pcheckeds = [];

                angular.forEach(filter, function (item, index) {
                    if ($filter("filter")(r.products, { abreviacion: item.abreviacion }).length == 0) {
                        item.id = idx;
                        item.idName = "ProdAvailable" + idx;
                        item.checked = parametricsprod_checkeds ? $filter("filter")(parametricsprod_checkeds, { abreviacion: item.abreviacion }).length > 0 ? true : false : false;
                        item.image = item.abreviacion + ".png";
                        r.products.push(item);
                        idx += 1;
                    }
                });
                                
                angular.forEach(r.products, function (item, index) {
                    if (item.checked) {
                        pcheckeds.push(item);
                    }
                })
                memory.storage.set("product_available_checkeds", pcheckeds);
                //local.returnJsonPush("product_available_checkeds", r.fromStorage.productosChequeados);

                return pcheckeds.length == 0 || pcheckeds == null ? false : true;
            },
            getParam: function(nameStorage){                
                var st = memory.storage.get(nameStorage);

                return st;
            },
            load: function () {
                var code = memory.storage.get("parametrics_codigo");

                if (!code || code != "200") {
                    memory.storage.clearAll();
                    paramsPromise.getParametrics(local.versionParams, "parametricos").then(function (data_) {
                        var data = data_.data;

                        if (data != undefined && data != null) {
                            var result = angular.fromJson(data);

                            angular.forEach(result, function (item, index) {
                                memory.storage.set("parametrics_" + index, result[index]);
                            }) 
                                                       
                            r.state = true;
                        } else {
                            $log.warn("Advertencia: Los datos paramétricos para la aplicación no podrán ser almacenados.");                            
                        }
                    });

                } else {
                    r.state = true;
                }
            }
        }

        return r;
    }]);




/*########################################-----###############################################*/




//app.factory('parametrics', ['memory', 'paramsPromise', '$filter', '$log',
//    function (memory, paramsPromise, $filter, $log) {
//        var local = {
//            returnJsonPush: function (storageName, obj) {
//                obj.splice(0, obj.length)

//                var json = angular.fromJson(memory.storage.get(storageName));

//                angular.forEach(json, function (item, index) {
//                    obj.push(item);
//                })
//            },
//            storageToObjects: function () {
//                local.returnJsonPush("parametrics_tiposIdentificacion", r.fromStorage.tiposIdentificacion);
//                local.returnJsonPush("parametrics_ocupaciones", r.fromStorage.ocupaciones);
//                local.returnJsonPush("parametrics_fuerzasMilitares", r.fromStorage.fuerzasMilitares);
//                local.returnJsonPush("parametrics_estadosCiviles", r.fromStorage.estadosCiviles);
//                local.returnJsonPush("parametrics_rangosFuerzas", r.fromStorage.rangosFuerzas);
//                local.returnJsonPush("parametrics_localizaciones", r.fromStorage.localizaciones);
//                local.returnJsonPush("parametrics_textosJuridicos", r.fromStorage.textosJuridicos);
//                local.returnJsonPush("parametrics_diasPagos", r.fromStorage.diasPagos);
//                local.returnJsonPush("parametrics_enviosCorrespondencia", r.fromStorage.enviosCorrespondencia);
//                local.returnJsonPush("parametrics_eps", r.fromStorage.eps);
//                local.returnJsonPush("parametrics_tiposContratos", r.fromStorage.tiposContratos);
//                local.returnJsonPush("parametrics_tiposVehiculos", r.fromStorage.tiposVehiculos);
//                local.returnJsonPush("parametrics_parentescos", r.fromStorage.parentescos);
//                local.returnJsonPush("parametrics_tiposOperacionesExtranjeras", r.fromStorage.tiposOperacionesExtranjeras);
//                local.returnJsonPush("parametrics_tiposCuentasExtranjeras", r.fromStorage.tiposCuentasExtranjeras);
//                local.returnJsonPush("parametrics_monedas", r.fromStorage.monedas);

//                local.returnJsonPush("product_available_checkeds", r.fromStorage.productosChequeados);
//            }
//        }
//        var r = {
//            state: false,
//            products: [],
//            enableCheckedsProduct: function () {
//                var pcheckeds = [];
//                angular.forEach(r.products, function (item, index) {
//                    if (item.checked) {
//                        pcheckeds.push(item);
//                    }
//                })
//                memory.storage.set("product_available_checkeds", pcheckeds);
//                local.returnJsonPush("product_available_checkeds", r.fromStorage.productosChequeados);

//                return pcheckeds.length == 0 || pcheckeds == null ? false : true;
//            },
//            load: function () {
//                if (memory.storage.get("parametrics_codigo") || memory.storage.get("parametrics_codigo") != "200") {
//                    memory.storage.clearAll();
//                    paramsPromise.getParametrics(13).then(function (data_) {
//                        var data = data_.data;
                                              
//                        if (data != undefined && data != null) {
//                            var result = angular.fromJson(data);
                           
//                            angular.forEach(result, function (item, index) {
//                                memory.storage.set("parametrics_" + index, result[index]);
//                            })
//                            var parametricsprod = memory.storage.get("parametrics_productos");
//                            var parametricsprod_checkeds = memory.storage.get("product_available_checkeds");
//                            var filter = $filter("filter")(parametricsprod, { estado: "1" });
//                            var idx = 1;
//                            angular.forEach(filter, function (item, index) {
//                                if ($filter("filter")(r.products, { abreviacion: item.abreviacion }).length == 0) {
//                                    item.id = idx;
//                                    item.idName = "ProdAvailable" + idx;
//                                    item.checked = parametricsprod_checkeds ? $filter("filter")(parametricsprod_checkeds, { abreviacion: item.abreviacion }).length > 0 ? true : false : false;
//                                    item.image = "card-empty.png";
//                                    r.products.push(item);
//                                    idx += 1;
//                                }
//                            })

//                            r.enableCheckedsProduct();
//                            local.storageToObjects();

//                            r.state = true;
//                        } else {
//                            $log.warn("Advertencia: Los datos paramétricos para la aplicación no podrán ser almacenados.");
//                        }
//                    });
//                }
//            },
//            fromStorage: {
//                tiposIdentificacion: [],
//                ocupaciones: [],
//                fuerzasMilitares: [],
//                estadosCiviles: [],
//                rangosFuerzas: [],
//                localizaciones: [],
//                textosJuridicos: [],
//                productosChequeados: [],
//                enviosCorrespondencia: [],
//                eps: [],
//                diasPagos: [],
//                tiposContratos: [],
//                tiposVehiculos: [],
//                parentescos: [],
//                tiposOperacionesExtranjeras: [],
//                tiposCuentasExtranjeras: [],
//                monedas: []
//            },
//        }

//        return r;
//    }]);