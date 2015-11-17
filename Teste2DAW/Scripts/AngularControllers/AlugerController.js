angular.module('MyApp')
.controller('AlugerController', function ($scope, AlugerService) {
    $scope.Mensagem = "bnnb mm";
    $scope.FilmeID = null;
    $scope.CopiaID = null;
    $scope.TemaIDP = null;
    $scope.UtenteID = null;
    $scope.FilmeList = null;
    $scope.CopiaList = null;
    $scope.TemaList = null;
    $scope.UtenteList = null;
    $scope.IsFormValid = false;
    $scope.AlugerID1 = null;
    $scope.textoComboBoxes= "Selecione uma Copia";
    $scope.textoComboBoxes1 = "Selecione um Tema";
    $scope.textoComboBoxes2 = "Selecione um Utente ";
    $scope.Result = "";
    $scope.Registo = false;

    $scope.Aluger = {
        AlugerID: '',
        UtenteID: '',
        datadevolucao:''
    };

    AlugerService.GetFilme().then(function (d) {
        $scope.FilmeList = d.data;
    }, function (error) {
        alert('Falha na leitura 1!!!')
    });
    AlugerService.GetUtente().then(function (d) {
        $scope.UtenteList = d.data;
    }, function (error) {
        alert('Falha na leitura 1!!!')
    });

    $scope.GetCopia = function () {
        $scope.CopiaID = null;
        $scope.CopiaList = null;

        if ($scope.FilmeID!=null) {
        $scope.textoComboBoxes= " A processar...";


        AlugerService.GetCopia($scope.FilmeID).then(function (d) {
            $scope.CopiaList = d.data;

            $scope.textoComboBoxes= "Selecione uma Copia";

        }, function (error) {
            alert('Falha na leitura  2!!!')
        });
    }
    }

    $scope.GetTemas = function () {
        $scope.TemaIDP = null;
        $scope.TemaList = null;
        $scope.textoComboBoxes1 = "A processar ...";

        if ($scope.CopiaID != null) {
        AlugerService.GetTemas($scope.CopiaID).then(function (d) {
            $scope.TemaList = d.data;
            $scope.textoComboBoxes1 = "Selecione um tema";

        }, function (error) {
            alert('Falha na leitura  3!!!')
        });
    }
    }


    $scope.$watch('f1.$valid', function (newVal) {
        $scope.IsFormValid = newVal;
    });


    $scope.Opcaolist = [];

    $scope.load = function () {
        AlugerService.GetOpcoes($scope.AlugerID1).then(function (d) {
            $scope.Opcaolist = d.data;
        });
    }


    $scope.SaveData = function () {
           
        $scope.Registo = true;
        AlugerService.SaveFormData($scope.Aluger).then(function (d) {
            $scope.AlugerID1 = d;
            $scope.load($scope.AlugerID1);
            });
        
            
    }

   

    

    $scope.Opcao = {
        OpcaoID: '',
        designacao: '',
        IsCorrect: false,
        AlugerID:''
                
    }

    $scope.clear = function () {
        $scope.Opcao.OpcaoID = '';
        $scope.Opcao.designacao = '';
        $scope.Opcao.IsCorrect=false;       
    }

    $scope.save = function () {
        $scope.Opcao.AlugerID = $scope.AlugerID1;
        alert($scope.Opcao.IsCorrect);

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify($scope.Opcao),
            url: '/Aluger/save',
            success: function (data, status) {
                $scope.clear();
                $scope.load();
            },
            error: function (status) { }
        });
    };

    $scope.edit = function (index) {
        $scope.Opcao.OpcaoID = index.Opcao;
        $scope.Opcao.designacao = index.designacao;
        $scope.Opcao.IsCorrect = index.IsCorrect;
    };

    $scope.update = function () {
        $scope.Opcao.AlugerID = $scope.AlugerID1;
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify($scope.Opcao),
            url: '/Aluger/update',
            success: function (data, status) {
                console.log(data)
                $scope.clear();
                $scope.load();
            },
            error: function (status) { }
        });
    };

    $scope.delete = function (data) {
        var state = confirm("Deseja mesmo apagar esse registo");
        if (state == true) {
            $.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                //data: "{ id: "+data.id+" }",
                data: JSON.stringify(data),
                url: '/Aluger/deleteOpcao',
                success: function (status) {
                    console.log(status)
                    $scope.load();
                },
                error: function (status) { }
            });
        }
    }
    $scope.Boas=0;
    $scope.Razoaveis=0;
    $scope.Mas=0;
    
    AlugerService.GetCopiaBoas().then.(function(d){
        $scope.Boas=d.data; 
    })
    AlugerService.GetCopiaBoas().then.(function(d){
        $scope.Rozoaveis=d.data; 
    })
    AlugerService.GetCopiaBoas().then.(function(d){
        $scope.Mas=d.data; 
    })
})
.factory('AlugerService', function ($http,$q) {
    var fac = {};

    ///questoes---------------------------------------
    fac.GetFilme = function () {
        return $http.get('/Alugers/GetFilme');
    }
    fac.GetCopiaBoas = function () {
        return $http.get('/Alugers/getCopiaBoas');
    }

    fac.GetCopiaRazoaveis = function () {
        return $http.get('/Alugers/getCopiaRazoaveis');
    }
    fac.GetCopiaMas = function () {
        return $http.get('/Alugers/getCopiaMas');
    }



    fac.GetUtente = function () {
        return $http.get('/Alugers/GetUtente');
    }

    fac.GetCopia = function (FilmeID) {
        return $http.get('/Alugers/GetCopia?FilmeID=' + FilmeID);
    }

    

    fac.GetOpcoes = function (AlugerID) {
        return $http.get('/Alugers/GetOpcoes?AlugerID=' + AlugerID);
    }
    
    fac.SaveFormData = function (data) {
        var defer = $q.defer();

        $http({
            url: '/Alugers/Register',
            method: 'POST',
            data: JSON.stringify(data),
            headers: { 'content-type': 'application/json' }
        })
            .success(function (d) {

                defer.resolve(d);
            }).error(function (e, err) {
                alert('falha!!');
                console.log(e);
                console.log(err);
                defer.reject(e);
            });
        



        return defer.promise;
    }

    // opcoes--------------------- ----------------------------



    return fac;
});