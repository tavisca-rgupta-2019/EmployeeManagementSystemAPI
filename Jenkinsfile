pipeline {
    agent any
	parameters {
		string(name:'SOLUTION_FILE_PATH', defaultValue:'EMSPracticeAPI.sln')
		string(name : 'TEST_PROJECT_PATH', defaultValue: 'EMSPracticeAPI.Test/EMSPracticeAPI.Test.csproj')
		 string(name : 'PROJECT_FILE_PATH', defaultValue: 'EMSPracticeAPI/EMSPracticeAPI.csproj')
		string(name : 'SOLUTION_DLL_FILE', defaultValue: 'EMSPracticeAPI.dll')
		choice(name: 'RELEASE_ENVIRONMENT',choices: ['Build','Test','Publish'],decription:'Pick Something')
	}

    stages {
        stage('Build') {
		when{ anyOf{expression{params.RELEASE_ENVIRONMENT=='Build'};
			     expression{params.RELEASE_ENVIRONMNENT=='Test'};
			     expression{params.RELEASE_ENVIRONMENT=='Publish'}
			    }
		     }
            		steps {
                powershell'''
				dotnet restore ${SOLUTION_FILE_PATH} --source https://api.nuget.org/v3/index.json
				dotnet build ${SOLUTION_FILE_PATH} -p:Configuration=release -v:n
                           '''
			
            }
        }
        stage('Test') {
		when{expression{params.RELEASE_ENVIRONMENT=='Test'}
		}
            steps {
                powershell'''
			dotnet test ${TEST_PROJECT_PATH}
			  '''
            }
        }
        stage('Publish') {
		when{ expression{params.RELEASE_ENVIRONMENT=='Publish'}
		    }
            steps {
                echo 'PUBLISHING....'
            }
        }
    }
}