import { Typography } from '@equinor/eds-core-react'
import { StyledCenteredPage } from '../UnauthorizedPage/UnauthorizedPage'
import { translateText } from 'components/Contexts/LanguageContext'

export const UnknownErrorPage = () => {
    var errorMessage = 'An unknown error has occurred'
    return (
        <StyledCenteredPage>
            <Typography variant="h1">{translateText(errorMessage)}</Typography>
        </StyledCenteredPage>
    )
}
