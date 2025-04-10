pipeline {
    agent any
    
    stages {
        stage('Checkout') {
            steps { git branch: 'main', url: 'https://github.com/turepo' }
        }
        
        stage('Build') {
            steps { bat 'dotnet build --configuration Release' }
        }

        stage('Run Tests') {
            steps {
                bat '''
                    if exist "TestResults" rmdir /Q /S "TestResults"
                    if exist "allure-results" rmdir /Q /S "allure-results"
                    
                    dotnet test --configuration Release --logger "trx" --logger "console;verbosity=detailed"
                    
                    xcopy /Y /Q "bin\\Release\\net8.0\\allure-results\\*" "allure-results\\"
                '''
            }
        }
    } 

    post {
        always {
            allure([results: [[path: 'allure-results']])
            archiveArtifacts artifacts: '**/TestResults/**'
        }
    }
}